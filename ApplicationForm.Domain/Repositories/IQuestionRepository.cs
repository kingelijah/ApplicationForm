using ApplicationForm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Domain.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<IEnumerable<Question>> GetByTypeAsync(string type);
        Task AddAsync(Question question);
        Task AddCandidateAsync(CandidateInfo info);
        Task UpdateAsync(Question question);
    }
}
