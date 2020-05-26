using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Question
    {

        public string TextQuestion { get; set; }
        public Dictionary<string, bool> Answers;

        public Question()
        {
            Answers = new Dictionary<string, bool>();
        }

    }
}
