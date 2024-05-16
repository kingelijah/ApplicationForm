using ApplicationForm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question>? Questions { get; set; }
        public DbSet<CandidateInfo>? candidateInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "ApplicationForm");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                    .ToContainer("Questions") // ToContainer
                    .HasPartitionKey(e => e.Id); // Partition Key

            modelBuilder.Entity<CandidateInfo>()
                .ToContainer("CandidateInfos") // ToContainer
                .HasPartitionKey(c => c.Id); // Partition Key

        }

    }
}
