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
        public List<Question> Questions { get; set; }
        public Dictionary<uint, List<string>> AllAnswers { get; set; }
        public Dictionary<uint, List<string>> AnswersCorrect { get; set; }
        public Dictionary<uint, List<bool>> CorrectAnswers { get; set; }
        public Dictionary<uint, List<string>> UserAnswers { get; set; }
        public Dictionary<uint, List<bool>> UserCorrectnessAnswers { get; set; }

        public Score(uint idQuiz, List<Question> questions)
        {
            IdQuiz = idQuiz;
            Questions = questions;
            UserAnswers = new Dictionary<uint, List<string>>();
            UserCorrectnessAnswers = new Dictionary<uint, List<bool>>();
            AllAnswers = new Dictionary<uint, List<string>>();
            AnswersCorrect = new Dictionary<uint, List<string>>();
            CorrectAnswers = new Dictionary<uint, List<bool>>();

            GetCorrectAnswersFromQuestions();
        }

        public double GetPoints(uint answerId)
        {
            bool isMultitype = Questions[(int)answerId - 1].
                            QuestionType.
                            Equals("checkbox");

            double points = isMultitype? 1:0;

            if (isMultitype)
            {
                foreach (bool answer in UserCorrectnessAnswers[answerId])
                {
                    if (!answer)
                    {
                        points -= 1.0 / AllAnswers[answerId].Count;
                    }
                }

                foreach(string ansCorrect in AnswersCorrect[answerId])
                {
                    if (!UserAnswers[answerId].Contains(ansCorrect))
                    {
                        points -= 1.0 / AllAnswers[answerId].Count;
                    }
                }
            }
            else
            {
                if (UserCorrectnessAnswers[answerId][0])
                    points++;
            }

            if (points < 0)
                return 0;
            return points;
        }

        public double GetPoints()
        {
            double points = 0;

            for (uint i = 1; i <= Questions.Count; i++)
                points += GetPoints(i);
            return points;
        }

        public double GetPercent()
        {
            return GetPoints() / Questions.Count * 100;
        }

        public void CheckAnswers()
        {
            for (uint i = 1; i <= Questions.Count; i++)
            {
                List<string> userAnswers = new List<string>();
                if (UserAnswers.ContainsKey(i))
                    userAnswers = UserAnswers[i];
                else
                    UserAnswers.Add(i, new List<string>());
                List<bool> correctAnswers = CorrectAnswers[i];
                List<bool> userCorrectnessAnswers = new List<bool>();

                    for (int j = 0; j < userAnswers.Count; j++)
                    {
                        if (correctAnswers[GetIdAnswer(userAnswers[j], i)])
                            userCorrectnessAnswers.Add(true);
                        else
                            userCorrectnessAnswers.Add(false);
                    }
                UserCorrectnessAnswers.Add(i, userCorrectnessAnswers);
            }
        }

        private int GetIdAnswer(string userAnswer, uint quesionId)
        {
            for (int i = 0; i < AllAnswers[quesionId].Count; i++)
                if (userAnswer.Equals(AllAnswers[quesionId][i]))
                    return i;
            return -1;
        }

        private void GetCorrectAnswersFromQuestions()
        {
            uint numberQuestion = 1;
            foreach (Question question in Questions)
            {
                List<string> answers = new List<string>() { question.Answer1, question.Answer2, question.Answer3, question.Answer4,
                                       question.Answer5, question.Answer6, question.Answer7, question.Answer8};
                List<bool> answersBool = new List<bool>(){ question.Answer1Bool==true?true:false, question.Answer2Bool==true?true:false, question.Answer3Bool==true?true:false, question.Answer4Bool==true?true:false,
                                       question.Answer5Bool==true?true:false, question.Answer6Bool==true?true:false, question.Answer7Bool==true?true:false, question.Answer8Bool==true?true:false};
                List<string> ansCor = new List<string>();
                for (int i=0;  i< answersBool.Count; i++)
                {
                    if (answersBool[i])
                        ansCor.Add(answers[i]);
                }

                AllAnswers.Add(numberQuestion, answers);
                CorrectAnswers.Add(numberQuestion, answersBool);
                AnswersCorrect.Add(numberQuestion, ansCor);
                numberQuestion++;
            }
        }

        public void AddToUserAnswers(uint key, string val)
        {
            if (UserAnswers.ContainsKey(key))
                UserAnswers[key].Add(val);
            else
            {
                UserAnswers.Add(key, new List<string>());
                UserAnswers[key].Add(val);
            }
        }


    }

}
