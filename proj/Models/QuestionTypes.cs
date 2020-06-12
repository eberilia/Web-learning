using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class QuestionTypes
    {
        public const string SINGLE = "Pojedynczy wybór";
        public const string MULTIPLE = "Wielokrotny wybór";

        public static readonly Dictionary<string, string> TYPES = new Dictionary<string, string>{

            { "radio", SINGLE}, 
            { "checkbox", MULTIPLE}
        
        };

       

    }
}
