using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class SQLQuizRepository : IQuiz
    {
        private readonly AppDbContext context;
        public SQLQuizRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Quiz AddQuestionToQuiz(Quiz quiz, Question question)
        {
            quiz.Questions.Add(question);
            return UpdateQuiz(quiz);
        }

        public Quiz AddQuiz(Quiz quiz)
        {
            context.Quizes.Add(quiz);
            context.SaveChanges();
            return quiz;
        }

        public Quiz DeteleQuiz(int id)
        {
            Quiz q = context.Quizes.Find(id);
            if (q != null)
            {
                context.Quizes.Remove(q);
                context.SaveChanges();
            }
            return q;
        }

        public IEnumerable<Quiz> GetAllQuizes()
        {
            return context.Quizes;
        }

        public Quiz GetQuiz(uint id)
        {
            return context.Quizes.Find(id);
        }

        public Quiz UpdateQuiz(Quiz quizChange)
        {
            var q = context.Quizes.Attach(quizChange);
            q.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return quizChange;
        }
    }
}
