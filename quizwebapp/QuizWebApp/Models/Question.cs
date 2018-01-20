using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using QuizWebApp.Enums;


namespace QuizWebApp.Models
{
    public class Question
    {
        //public Question()
        //{
        //    Answers = new List<Answer>();
        //}
        public int Id { get; set; }

        [Required]
        public string Questions { get; set; }

        //difficulty level
        public int LevelId { get; set; }

        [NotMapped]
        public Level Level { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public Category Category { get; set; }

        //navigation properties
        public List<Answer> Answers { get; set; } = new List<Answer>();

       


    }
}
