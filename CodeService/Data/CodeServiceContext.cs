#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeService.Models;

namespace CodeService.Data
{
    public class CodeServiceContext : DbContext
    {
        public CodeServiceContext (DbContextOptions<CodeServiceContext> options)
            : base(options)
        {
        }

        // TODO : Register The Many-to-Many Relationships

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<CodeQuestion> CodeQuestions { get; set; }
        public DbSet<QuestionSkeleton> QuestionSkeletons { get; set; }
    }
}
