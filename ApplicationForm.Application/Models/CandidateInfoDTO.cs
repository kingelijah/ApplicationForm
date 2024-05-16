using ApplicationForm.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Models
{
    public class CandidateInfoDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public List<AdditionalQuestionDTO>? AdditionalQuestions { get; set; }

    }
    public class CandidateInfoValidator : AbstractValidator<CandidateInfoDTO>
    {
        public CandidateInfoValidator()
        {
            RuleFor(contact => contact.FirstName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.LastName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.IDNumber).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.CurrentResidence).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.Gender).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.Email).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.Nationality).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.Phone).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
