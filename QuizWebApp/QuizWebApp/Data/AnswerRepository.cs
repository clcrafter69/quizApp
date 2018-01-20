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
            _dbContext.Answers.Remove(answerToDelete);
            _dbContext.SaveChanges();
           // throw new NotImplementedException();
        }

        public Answer GetAnswerById(int id)
        {
            return _dbContext.Answers.Find(id);
            //throw new NotImplementedException();
        }

        public List<Answer> ListAllAnswers()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnswer(Answer changedAnswer)
        {
            _dbContext.Entry<Answer>(changedAnswer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            //throw new NotImplementedException();
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
