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

        //public List<string> TextAnswers { get; set; }
        //public List<bool> Answers { get; set; }

        public Question()
        {
            Answers = new Dictionary<string, bool>();
            //TextAnswers = new List<string>();
            //Answers = new List<bool>();


        }

    }
}
