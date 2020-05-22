using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Score
    {
        uint points;

        public Score()
        {
            points = 0;
        }

        public uint getPoints()
        {
            return points;
        }

        public void PointPlusPlus()
        {
            points++;
        }

        

    }
}
