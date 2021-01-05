﻿using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
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

        [HttpGet]
        public List<Applicant> Get()
        {
            return _applicantBusinessService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Applicant> Get(int id)
        {
            var applicant = _applicantBusinessService.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            else
            {
                return applicant;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var applicant = _applicantBusinessService.GetById(id);
                if (applicant == null)
                {
                    return NotFound();
                }
                int result = _applicantBusinessService.Delete(applicant);
                if (result > 0)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500, "Server error! Delete operation failed.");
                }
            }
            catch(Exception E)
            {
                return StatusCode(500, "Server error! Delete operation failed.");
            }
        }
    }
}
