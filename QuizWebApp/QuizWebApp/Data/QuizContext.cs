using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWebApp.Models;

namespace QuizWebApp.Data
{
    public class QuizContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ScoreLevel> Scores { get; set; }
        public DbSet<Leaderboard> Leaders { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options)
            :base(options)
            {

        }
    }
}
