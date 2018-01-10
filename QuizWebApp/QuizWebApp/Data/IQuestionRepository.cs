using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizWebApp.Models;

namespace QuizWebApp.Data
{
    public interface IQuestionRepository
    {
        Question AddQuestion(Question newQuestion);
        void DeleteQuestion(Question questionToDelete);
        Question GetQuestionById(int id);
        List<Question> ListAllQuestions();
        void UpdateQuestion(Question changedQuestion);
        List<Answer> GetQuestionAndAnsByID(int id);
        List<Question> ListAllQuestionsByCategory(int level, int category);
        Question GetQAnswers(int id);
    }
}
