using ApplicationForm.Application.Interfaces;
using ApplicationForm.Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public ApplicationController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpGet("/GetQuestionByType{type}")]
        public async Task<ActionResult<QuestionDTO>> GetQuestionByTypeAsync(string type)
        {
            var question = await _questionService.GetByTypeAsync(type);
            return Ok(question);
        }

        [HttpPost("/AddQuestion")]
        public async Task<ActionResult> AddQuestionAsync(QuestionDTO question)
        {
            await _questionService.AddAsync(question);
            return NoContent();
        }


        [HttpPost("/AddCandidateInfo")]
        public async Task<ActionResult> AddCandidateInfoAsync(CandidateInfoDTO info)
        {
            await _questionService.AddCandidateAsync(info);
            return NoContent();
        }

        [HttpPut("/UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestionAsync(QuestionDTO question)
        {
           
            await _questionService.UpdateItemAsync(question);

            return NoContent();
        }

    }
}
