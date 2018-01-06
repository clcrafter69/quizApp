using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApp.Enums
{
    public enum Level
    {

            [Description("Beginner")]
            Beginner = 1,
            [Description("Intermediate")]
            Intermediate = 2,
            [Description("Advanced")]
            Advanced = 3
        
    }
}
