using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuizWebApp.Enums
{
    public enum Category
    {

        [Description("History")]
         History = 1,
        [Description("Science")]
         Science = 2,
        [Description("Literature")]
         Literature = 3,
        [Description("Finance")]
         Finance = 4
    }
}
