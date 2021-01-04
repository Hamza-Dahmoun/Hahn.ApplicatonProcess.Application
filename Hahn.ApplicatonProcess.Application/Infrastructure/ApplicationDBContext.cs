using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext():base()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            AddTestData(this);
        }
        private static void AddTestData(ApplicationDBContext context)
        {
            Applicant applicant1 = new Applicant { ID = 1, Name = "Hamza", FamilyName = "Dahmoun", Age = 33, CountryOfOrigin = "Algeria", Address = "Chiffa, Blida", EmailAddress = "hamza.dahmoun7@gmail.com", Hired = true };
            Applicant applicant2 = new Applicant { ID = 2, Name = "John", FamilyName = "Doe", Age = 33, CountryOfOrigin = "UK", Address = "Manchester", EmailAddress = "john.doe@gmail.com", Hired = true };
            Applicant applicant3 = new Applicant { ID = 3, Name = "Ahmed", FamilyName = "Mohamed", Age = 33, CountryOfOrigin = "Egypt", Address = "Cairo", EmailAddress = "ahmed.mohamed@gmail.com", Hired = true };

            context.Applicant.Add(applicant1);
            context.Applicant.Add(applicant2);
            context.Applicant.Add(applicant3);
            context.SaveChanges();
        }


        public DbSet<Applicant> Applicant { get; set; }
    }
}
