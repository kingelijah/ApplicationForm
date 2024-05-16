using ApplicationForm.Domain.Entities;
using ApplicationForm.Domain.Repositories;
using ApplicationForm.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Infrastructure.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions?.ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetByTypeAsync(string type)
        {
            return await _context.Questions?.Where(e=>e.Type == type).ToListAsync();
        }

        public async Task AddAsync(Question question)
        {
            _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddCandidateAsync(CandidateInfo info)
        {
            _context.candidateInfos.AddAsync(info);
            await _context.SaveChangesAsync();
        }

    }
}

