using Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
    public static class Extensions
    {
        public static ApplicantDTO AsDTO(this Applicant applicant)
        {
            return new ApplicantDTO
            {
                ID = applicant.ID,
                Name = applicant.Name,
                FamilyName = applicant.FamilyName,
                Age = applicant.Age,
                Address = applicant.Address,
                EmailAddress = applicant.EmailAddress,
                CountryOfOrigin = applicant.CountryOfOrigin,
                Hired = applicant.Hired
            };
        }
    }
}
