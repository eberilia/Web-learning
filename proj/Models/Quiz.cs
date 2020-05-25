using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Quiz
    {
        public uint IdQuiz { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
        }

    }
}
