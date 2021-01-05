using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs;
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
        public List<ApplicantDTO> Get()
        {
            return _applicantBusinessService.GetAll().Select(applicant =>applicant.AsDTO()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ApplicantDTO> Get(int id)
        {
            var applicant = _applicantBusinessService.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            else
            {
                return applicant.AsDTO();
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
        public ActionResult Update(int id, UpdateApplicantDTO applicantDTO)
        {
            try
            {
                var existingApplicant = _applicantBusinessService.GetById(id);
                if (existingApplicant == null)
                {
                    return NotFound();
                }

                existingApplicant.Name = applicantDTO.Name;
                existingApplicant.FamilyName = applicantDTO.FamilyName;
                existingApplicant.Age = applicantDTO.Age;
                existingApplicant.Address = applicantDTO.Address;
                existingApplicant.EmailAddress = applicantDTO.EmailAddress;
                existingApplicant.CountryOfOrigin = applicantDTO.CountryOfOrigin;
                existingApplicant.Hired = applicantDTO.Hired;

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
        public ActionResult<ApplicantDTO> Create(CreateApplicantDTO applicantDTO)
        {
            try
            {
                Applicant applicant = new()
                {
                    Name = applicantDTO.Name,
                    FamilyName = applicantDTO.FamilyName,
                    Age = applicantDTO.Age,
                    Address = applicantDTO.Address,
                    EmailAddress = applicantDTO.EmailAddress,
                    CountryOfOrigin = applicantDTO.CountryOfOrigin,
                    Hired = applicantDTO.Hired
                };
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
