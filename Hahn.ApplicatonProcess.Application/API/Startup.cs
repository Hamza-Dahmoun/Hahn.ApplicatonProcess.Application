using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.DataAbstraction;
using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs;
using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs.Validators;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //registering localization service using json file
            services.AddJsonLocalization();

            //regiter an inMemory database context with a singleton life time so that CRUD operations on the data that are in memory will clear and understandable
            services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase(databaseName: "ApplicantsDB"), ServiceLifetime.Singleton);


            //registering ApplicantRepository
            services.AddTransient<IRepository<Applicant, int>, ApplicantRepository>();

            //registering ApplicantBusinessService
            services.AddTransient<ApplicantBusinessService>();

            //registering FluentValidation services
            services.AddControllers().AddFluentValidation();

            //registering fluentValidation for CreateApplicantDTO and UpdateApplicantDTO classes
            services.AddTransient<IValidator<CreateApplicantDTO>, CreateApplicantDTOValidator>();
            services.AddTransient<IValidator<UpdateApplicantDTO>, UpdateApplicantDTOValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE")
            };
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(options);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
