using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models.DTOs.Validators
{
    public class CreateApplicantDTOValidator:AbstractValidator<CreateApplicantDTO>
    {
        public CreateApplicantDTOValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0).WithMessage("Field 'ID' should be greater than 0, you entered {PropertyName}");
            RuleFor(a => a.Name).MinimumLength(5).WithMessage("Field 'Name' should contain at least 5 characters.");
            RuleFor(a => a.FamilyName).MinimumLength(5).WithMessage("Field 'FamilyName' should contain at least 5 characters");
            RuleFor(a => a.Address).MinimumLength(10).WithMessage("Field 'Address' should contain at least 5 characters");
            RuleFor(a => a.EmailAddress).EmailAddress().WithMessage("Field 'EmailAddress' should be a valid email address written in the following form: *@*.ValidDomain");
            RuleFor(a => a.Age).InclusiveBetween(20, 60).WithMessage("Field 'Age' should have value between 20 and 60");
            RuleFor(a => a.Hired).NotNull().WithMessage("Field 'Hired' should not be Null");
        }
    }
}
