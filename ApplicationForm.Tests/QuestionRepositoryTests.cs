using ApplicationForm.Application.Exceptions;
using ApplicationForm.Application.Models;
using ApplicationForm.Application.Services;
using ApplicationForm.Domain.Entities;
using ApplicationForm.Domain.Repositories;
using ApplicationForm.Infrastructure.Data;
using ApplicationForm.Infrastructure.DbContexts;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Tests
{
    public class QuestionRepositoryTests
    {
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private Mock<IValidator<QuestionDTO>> _validatorMock;
        private Mock<IValidator<CandidateInfoDTO>> _infovalidatorMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<QuestionService>> _logger;
        private Mock<AppDbContext> _contextMock;
        private QuestionService _questionService;
        public QuestionRepositoryTests()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _validatorMock = new Mock<IValidator<QuestionDTO>>();
            _infovalidatorMock = new Mock<IValidator<CandidateInfoDTO>>();
            _mapperMock = new Mock<IMapper>();
            _logger = new Mock<ILogger<QuestionService>>();
            _contextMock = new Mock<AppDbContext>();

            _questionService = new QuestionService(
                _questionRepositoryMock.Object,
                _mapperMock.Object,
                _contextMock.Object,
                _validatorMock.Object,
                _infovalidatorMock.Object,
                _logger.Object
            );
        }

        [Fact]
        public async Task GetByTypeAsync_ReturnsQuestions()
        {
            // Arrange
            var questions = new List<Question> { new Question { Name = "what is your age", Type = "paragraph" }, new Question { Name = "what is your age", Type = "paragraph" } };
            _questionRepositoryMock.Setup(x => x.GetByTypeAsync("paragraph")).ReturnsAsync(questions);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionDTO>>(questions)).Returns(new List<QuestionDTO> { new QuestionDTO { Name = "what is your age", Type = "paragraph" }, new QuestionDTO { Name = "what is your age",  Type = "paragraph" } });

            // Act
            var result = await _questionService.GetByTypeAsync("paragraph");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByTypeAsync_ReturnsNull_WhenNoQuestionsFound()
        {
            // Arrange
            _questionRepositoryMock.Setup(x => x.GetByTypeAsync("paragraph")).ReturnsAsync((IEnumerable<Question>)null);

            // Act
            var result = await _questionService.GetByTypeAsync("paragraph");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsync_AddsQuestion()
        {
            // Arrange
            var questionDto = new QuestionDTO {  Name = "what is your age", Type = "paragraph" };
            _mapperMock.Setup(x => x.Map<Question>(questionDto)).Returns(new Question { Name = "what is your age", Type = "paragraph" });
            _validatorMock.Setup(x => x.ValidateAsync(
                It.IsAny<QuestionDTO>(),  
                It.IsAny<CancellationToken>() 
            )).ReturnsAsync(new ValidationResult());
            // Act
             await _questionService.AddAsync(questionDto);

            // Assert
            _questionRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Question>()), Times.Once);
        }

        [Fact]
        public void AddAsync_ThrowsApplicationFormException_WhenValidationFails()
        {
            // Arrange
            var questionDto = new QuestionDTO();
            var validationFailures = new List<ValidationFailure> { new ValidationFailure("", "") };
            var validationResult = new ValidationResult(validationFailures);
            _validatorMock.Setup(x => x.ValidateAsync(
                           It.IsAny<QuestionDTO>(), 
                           It.IsAny<CancellationToken>() 
                       )).ReturnsAsync(new ValidationResult());
            // Act & Assert
            Assert.ThrowsAsync<ApplicationFormException>(async () => await _questionService.AddAsync(questionDto));
        }

        [Fact]
        public async Task UpdateItemAsync_UpdatesQuestion()
        {
            // Arrange
            var questionDto = new QuestionDTO();
            _validatorMock.Setup(x => x.ValidateAsync(
                           It.IsAny<QuestionDTO>(),  
                           It.IsAny<CancellationToken>() 
                       )).ReturnsAsync(new ValidationResult());
            // Act
            await _questionService.UpdateItemAsync(questionDto);

            // Assert
            _questionRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Question>()), Times.Once);
        }

        [Fact]
        public void UpdateItemAsync_ThrowsApplicationFormException_WhenValidationFails()
        {
            // Arrange
            var questionDto = new QuestionDTO();
            var validationFailures = new List<ValidationFailure> { new ValidationFailure("", "") };
            var validationResult = new ValidationResult(validationFailures);
            _validatorMock.Setup(x => x.ValidateAsync(
                           It.IsAny<QuestionDTO>(), 
                           It.IsAny<CancellationToken>()  
                       )).ReturnsAsync(new ValidationResult());
            // Act & Assert
            Assert.ThrowsAsync<ApplicationFormException>(async () => await _questionService.UpdateItemAsync(questionDto));
        }

    }
}
