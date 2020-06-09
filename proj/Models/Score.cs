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
        public List<string> UserAnswers { get; set; }
        public List<Question> Questions { get; set; }
        public List<string> CorrectAnswers { get; set; }

        //public Dictionary<uint, List<bool>> UserCorrectnessAnswers { get; set; }
        public List<bool> UserCorrectnessAnswers { get; set; }


        public Score()
        {
            UserAnswers = new List<string>();
            Questions = new List<Question>();
            UserCorrectnessAnswers = new List<bool>();
            CorrectAnswers = new List<string>();
            //UserCorrectnessAnswers = new Dictionary<uint, List<bool>>();


            //CorrectAnswers = new List<string>();
        }
        private void GetCorrectAnswersFromQuestions()
        {
            for(int i=0; i<Questions.Count; i++)
            {

                string[] ans = { Questions[i].Answer1, Questions[i].Answer2, Questions[i].Answer3, Questions[i].Answer4,
                               Questions[i].Answer5, Questions[i].Answer6, Questions[i].Answer7, Questions[i].Answer8};
                bool?[] ansBool = { Questions[i].Answer1Bool, Questions[i].Answer2Bool, Questions[i].Answer3Bool, Questions[i].Answer4Bool,
                               Questions[i].Answer5Bool, Questions[i].Answer6Bool, Questions[i].Answer7Bool, Questions[i].Answer8Bool};


                for (int j = 0; i < ans.Length; j++)
                {
                    if (ans[j] == null)
                        break;

                    if(ansBool[j] == true)
                    {
                        CorrectAnswers.Add(ans[j]);
                        break;
                    }
                }

            }
            
        }
        public List<bool> CheckAnswers()
        {
            GetCorrectAnswersFromQuestions();

            

            for(int i=0; i<UserAnswers.Count; i++)
            {
                if (UserAnswers[i].Equals(CorrectAnswers[i]))
                    UserCorrectnessAnswers.Add(true);
                else
                    UserCorrectnessAnswers.Add(false);

            }

         
            return UserCorrectnessAnswers;
        }

        public uint GetPoints()
        {
            uint points = 0;
            /*foreach(bool a in UserCorrectnessAnswers)
                if (a)
                    points++;*/
            
            for(int i=0; i<UserCorrectnessAnswers.Count; i++)
            {
                if (UserCorrectnessAnswers[i] == true)
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
