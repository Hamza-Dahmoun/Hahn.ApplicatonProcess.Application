using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        protected readonly ApplicantBusinessService _applicantBusinessService;
        public ApplicantController(ApplicantBusinessService applicantBusinessService)
        {
            _applicantBusinessService = applicantBusinessService;
        }
    }
}
