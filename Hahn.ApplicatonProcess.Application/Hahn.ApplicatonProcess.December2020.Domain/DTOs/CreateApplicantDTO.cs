using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs
{
    public record CreateApplicantDTO
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public string FamilyName { get; init; }
        public string Address { get; init; }
        public string CountryOfOrigin { get; init; }
        public string EmailAddress { get; init; }
        public int Age { get; init; }
        public bool Hired { get; init; }
    }
}
