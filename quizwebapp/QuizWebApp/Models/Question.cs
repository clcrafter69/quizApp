using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Questions { get; set; }

        //difficulty level
        public string Level { get; set; }
        public string Category { get; set; }  
        
       //navigation properties
        public List<Answer> Answers { get; set; }


    }
}
