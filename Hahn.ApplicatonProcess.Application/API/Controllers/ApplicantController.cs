using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, Applicant applicant)
        {
            try
            {
                var existingApplicant = _applicantBusinessService.GetById(id);
                if (existingApplicant == null)
                {
                    return NotFound();
                }

                existingApplicant.Name = applicant.Name;
                existingApplicant.FamilyName = applicant.FamilyName;
                existingApplicant.Age = applicant.Age;
                existingApplicant.Address = applicant.Address;
                existingApplicant.EmailAddress = applicant.EmailAddress;
                existingApplicant.CountryOfOrigin = applicant.CountryOfOrigin;
                existingApplicant.Hired = applicant.Hired;

                int result = _applicantBusinessService.Update(existingApplicant);
                if (result > 0)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500, "Server error! Update operation failed.");
                }
            }
            catch(Exception E)
            {
                return StatusCode(500, "Server error! Update operation failed.");
            }
        }

        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            try
            {
                int result = _applicantBusinessService.Add(applicant);
                if (result > 0)
                {
                    return CreatedAtAction(nameof(Get), new { applicant.ID }, applicant);
                }
                else
                {
                    return StatusCode(500, "Server error! Create operation failed.");
                }
            }
            catch (Exception E)
            {
                return StatusCode(500, "Server error! Create operation failed.");
            }
        }
    }
}
