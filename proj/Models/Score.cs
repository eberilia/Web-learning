﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Score
    {
        public List<bool> UserCorrectnessAnswers { get; set; }

        public uint GetPoints()
        {
            uint points = 0;

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