using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Models
{
    public class AnswerViewModel
    {
        public Answer Answers { get; set; }
        public int currentQuestionId { get; set; }
    }
}
