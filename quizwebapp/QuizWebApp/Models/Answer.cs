using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public bool Correct { get; set; }

        //navigation properties
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
