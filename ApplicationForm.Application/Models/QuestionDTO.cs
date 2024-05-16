using ApplicationForm.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Models
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    public class QuestionValidator : AbstractValidator<QuestionDTO>
    {
        public QuestionValidator()
        {
            RuleFor(contact => contact.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(contact => contact.Type).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
