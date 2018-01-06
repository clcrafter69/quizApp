using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizWebApp.Models;

namespace QuizWebApp.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        protected readonly QuizContext _dbContext;

        public QuestionRepository(QuizContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Question AddQuestion(Question newQuestion)
        {
            _dbContext.Questions.Add(newQuestion);
            _dbContext.SaveChanges();

            return newQuestion;
        }

        public void DeleteQuestion(Question questionToDelete)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            return _dbContext.Questions.Find(id);
        }
        public List<Answer> GetQuestionAndAnsByID(int id)
        {
            //return _dbContext.Questions.GroupJoin(a=> a.Answers, quest=> quest.Id, ans =>ans.questionId, (quest,ans)=> new {Key = quest.id, Answers = ans).Where(p => p.Id == id).ToList();
            return _dbContext.Answers.Where(a => a.QuestionId == id).ToList();
        }
        public List<Question> ListAllQuestions()
        {
            //return _dbContext.Questions
            //      .ToList();
            return _dbContext.Questions.Include(a=> a.Answers)
                  .ToList();
        }
        public List<Question> ListAllQuestionsByCategory(int level, int category)
        {
            return _dbContext.Questions.Where( a=>a.LevelId == level && a.CategoryId == category).OrderBy(a=>a.Id)
                  .ToList();
        }

        public void UpdateQuestion(Question changedQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
