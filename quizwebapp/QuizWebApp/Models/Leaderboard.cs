using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Models
{
    public class Leaderboard
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public DateTime attemptDate { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }

        public int ScoreId { get; set; }
        public ScoreLevel ScoreLevel { get; set; }
        
    }
}
