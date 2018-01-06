using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWebApp.Models;

namespace QuizWebApp.Data
{
    public class AnswerRepository : IAnswerRepository
    {

        protected readonly QuizContext _dbContext;

        public AnswerRepository(QuizContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Answer AddAnswer(Answer newAnswer)
        {
            _dbContext.Answers.Add(newAnswer);
            _dbContext.SaveChanges();

            return newAnswer;
        }

        public void DeleteAnswer(Answer answerToDelete)
        {
            throw new NotImplementedException();
        }

        public Answer GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Answer> ListAllAnswers()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnswer(Answer changedAnswer)
        {
            throw new NotImplementedException();
        }

        public List<Answer> ListEditAnswers(int id)
        {
            //return _dbContext.Answers.Include(q => q.Question)
            //    .Where(n => n.QuestionId == id)
            //          .ToList();
            return _dbContext.Answers
                .Where(n => n.QuestionId == id)
                      .ToList();

            //return _dbContext.Answers.Include(q => q.Question)
            //          .ToList();

        }
    }
}
