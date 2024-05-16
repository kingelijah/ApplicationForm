using ApplicationForm.Application.Interfaces;
using ApplicationForm.Application.Models;
using ApplicationForm.Application.Services;
using ApplicationForm.Domain.Repositories;
using ApplicationForm.Infrastructure.Data;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
         
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IValidator<QuestionDTO>, QuestionValidator>();
            services.AddScoped<IValidator<CandidateInfoDTO>, CandidateInfoValidator>();

        }
    }
}