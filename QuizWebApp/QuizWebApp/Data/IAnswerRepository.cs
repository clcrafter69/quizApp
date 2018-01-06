using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizWebApp.Models;

namespace QuizWebApp.Data
{
    public interface IAnswerRepository
    {
        Answer AddAnswer(Answer newBlog);
        void DeleteAnswer(Answer answerToDelete);
        Answer GetBlogById(int id);
        List<Answer> ListAllAnswers();
        void UpdateAnswer(Answer changedAnswer);
        List<Answer> ListEditAnswers(int id);
    }
}
