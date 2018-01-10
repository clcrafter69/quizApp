using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizWebApp.Models;

namespace QuizWebApp.Entities
{
    public class QuestionMap
    {

        public int Id { get; set; }
        public string Questions { get; set; }

        //difficulty level
        public int LevelId { get; set; }


        public int CategoryId { get; set; }


        //navigation properties
        public List<AnswerMap> Answers { get; set; } = new List<AnswerMap>();
    }
}
