using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Score
    {
        public uint IdQuiz { get; set; }
        public List<bool> UserCorrectnessAnswers { get; set; }

        public Score()
        {
            UserCorrectnessAnswers = new List<bool>();
        }


        public uint GetPoints()
        {
            uint points = 0;
            /*foreach(bool a in UserCorrectnessAnswers)
                if (a)
                    points++;*/
            
            for(uint i=0; i<UserCorrectnessAnswers.Count; i++)
            {
                if (UserCorrectnessAnswers[(int)i] == true)
                    points++;
            }

            return points;
        }

        public float GetPercent()
        {
            float percent = ( GetPoints() / (float)UserCorrectnessAnswers.Count) * 100;

            return percent;
        }



    }
}
