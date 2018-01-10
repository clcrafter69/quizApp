using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Entities
{
    public class AnswerMap
    {

        public int Id { get; set; }
        public string Response { get; set; }
        public bool Correct { get; set; }
    }
}
