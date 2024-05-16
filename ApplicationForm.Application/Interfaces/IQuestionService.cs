using ApplicationForm.Application.Models;
using ApplicationForm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetAllAsync();
        Task<IEnumerable<QuestionDTO>> GetByTypeAsync(string type);
        Task AddAsync(QuestionDTO question);
        Task AddCandidateAsync(CandidateInfoDTO info);
        Task UpdateItemAsync(QuestionDTO id);
    }
}
