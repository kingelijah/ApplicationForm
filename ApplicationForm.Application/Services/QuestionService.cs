using ApplicationForm.Application.Exceptions;
using ApplicationForm.Application.Interfaces;
using ApplicationForm.Application.Models;
using ApplicationForm.Domain.Entities;
using ApplicationForm.Domain.Repositories;
using ApplicationForm.Infrastructure.DbContexts;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private IValidator<QuestionDTO> _validator;
        private IValidator<CandidateInfoDTO> _infovalidator;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ILogger<QuestionService> _logger;


        public QuestionService(IQuestionRepository questionRepository, IMapper mapper, AppDbContext context, IValidator<QuestionDTO> validator, IValidator<CandidateInfoDTO> infovalidator, ILogger<QuestionService> logger)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _validator = validator;
            _context = context;
            _infovalidator = infovalidator;
            _logger = logger;

        }

     
        public async Task<IEnumerable<QuestionDTO>> GetByTypeAsync(string type)
        {
           var questions = await _questionRepository.GetByTypeAsync(type.ToLower());
            return questions != null ? _mapper.Map<IEnumerable<QuestionDTO>>(questions).ToList() : null;

        }

        public async Task<IEnumerable<QuestionDTO>> GetAllAsync()
        {
            var questions = await _questionRepository.GetAllAsync();
            return questions != null ? _mapper.Map<IEnumerable<QuestionDTO>>(questions).ToList() : null;
        }

        public async Task AddAsync(QuestionDTO question)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(question);

                if (!result.IsValid)
                    throw new ArgumentNullException(nameof(question));
                var newQuestion = _mapper.Map<Question>(question);
                newQuestion.Type.ToLower();
                await _questionRepository.AddAsync(newQuestion);
            }
            catch (ApplicationFormException ex) 
            {
                throw new ApplicationFormException();
            }
        }

        public async Task UpdateItemAsync(QuestionDTO question)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(question);

                if (!result.IsValid)
                    throw new ArgumentNullException(nameof(question));

                await _questionRepository.UpdateAsync(_mapper.Map<Question>(question));
            }
            catch (ApplicationFormException ex)
            {
                _logger.LogError(ex.ToString());
                throw new ApplicationFormException();
            }
        }

        public async Task AddCandidateAsync(CandidateInfoDTO info)
        {
            try
            {
                ValidationResult result = await _infovalidator.ValidateAsync(info);

                if (!result.IsValid)
                    throw new ArgumentNullException(nameof(info));
                var newInfo = _mapper.Map<CandidateInfo>(info);
                await _questionRepository.AddCandidateAsync(newInfo);
            }
            catch (ApplicationFormException ex)
            {
                _logger.LogError(ex.ToString());
                throw new ApplicationFormException();
            }
        }

    }
}
