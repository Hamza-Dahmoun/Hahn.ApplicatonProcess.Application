using FluentValidation;
using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices;
using Hahn.ApplicatonProcess.December2020.Domain.Business.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs;
using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<WeatherForecastController> _logger;
        public ApplicantController(ApplicantBusinessService applicantBusinessService, ILogger<WeatherForecastController> logger)
        {
            _applicantBusinessService = applicantBusinessService;
            _logger = logger;
        }

        [HttpGet]
        public List<ApplicantDTO> Get()
        {
            _logger.LogInformation("called applicant/get");
            return _applicantBusinessService.GetAll().Select(applicant =>applicant.AsDTO()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ApplicantDTO> Get(int id)
        {
            _logger.LogInformation("called applicant/get/id");
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
                _logger.LogInformation("called applicant/delete/id");
                var applicant = _applicantBusinessService.GetById(id);
                if (applicant == null)
                {
                    _logger.LogWarning("applicant to delete with id " + id.ToString() + " is NotFound!");
                    return NotFound();
                }
                _applicantBusinessService.Delete(applicant);
                _logger.LogInformation("applicant with id " + id.ToString() + " is deleted successfully");
                return NoContent();
            }
            catch (DataNotUpdatedException E)
            {
                _logger.LogError("server error! could not delete applicant with id " + id.ToString());
                return StatusCode(500, "Server error! " + E.Message);
            }
            catch (Exception E)
            {
                _logger.LogError("server error! " + E.Message);
                return StatusCode(500, "Server error!");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateApplicantDTO applicantDTO)
        {
            try
            {
                _logger.LogInformation("called applicant/update/id");
                var existingApplicant = _applicantBusinessService.GetById(id);
                if (existingApplicant == null)
                {
                    _logger.LogWarning("applicant to update with id " + id.ToString() + " is NotFound!");
                    return NotFound();
                }

                existingApplicant.Name = applicantDTO.Name;
                existingApplicant.FamilyName = applicantDTO.FamilyName;
                existingApplicant.Age = applicantDTO.Age;
                existingApplicant.Address = applicantDTO.Address;
                existingApplicant.EmailAddress = applicantDTO.EmailAddress;
                existingApplicant.CountryOfOrigin = applicantDTO.CountryOfOrigin;
                existingApplicant.Hired = applicantDTO.Hired;

                _applicantBusinessService.Update(existingApplicant);
                _logger.LogInformation("applicant with id " + id.ToString() + " is updated successfully");
                return NoContent();
            }
            catch (BusinessException E)
            {
                _logger.LogError("business rule not met when trying to update applicant with id " + id.ToString() + ". " + E.Message);
                return StatusCode(400, "Server error! " + E.Message);
            }
            catch (DataNotUpdatedException E)
            {
                _logger.LogError("server error! could not update applicant with id " + id.ToString());
                return StatusCode(500, "Server error! " + E.Message);
            }
            catch (Exception E)
            {
                _logger.LogError("server error! " + E.Message);
                return StatusCode(500, "Server error!");
            }
        }

        [HttpPost]
        public ActionResult<ApplicantDTO> Create(CreateApplicantDTO applicantDTO)
        {
            try
            {
                _logger.LogInformation("called applicant/create/id");
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

                _applicantBusinessService.Add(applicant);
                _logger.LogInformation("applicant with id " + applicant.ID.ToString() + " is inserted successfully");
                return CreatedAtAction(nameof(Get), new { applicant.ID }, applicant);
            }
            catch (BusinessException E)
            {
                _logger.LogError("business rule not met when trying to insert new applicant. " + E.Message);
                return StatusCode(400, "Server error! " + E.Message);
            }
            catch (DataNotUpdatedException E)
            {
                _logger.LogError("server error! could not insert the new applicant");
                return StatusCode(500, "Server error! " + E.Message);
            }
            catch (Exception E)
            {
                _logger.LogError("server error! " + E.Message);
                return StatusCode(500, "Server error! Create operation failed.");
            }
        }
    }
}
