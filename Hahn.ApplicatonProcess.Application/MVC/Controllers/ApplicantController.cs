using Microsoft.AspNetCore.Mvc;
using MVC.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ApplicantApiService _applicantApiService;

        public ApplicantController(ApplicantApiService applicantApiService)
        {
            _applicantApiService = applicantApiService;
        }

        public IActionResult Index()
        {
            var applicants = _applicantApiService.GetAllAsync();
            return View(applicants);
        }
    }
}
