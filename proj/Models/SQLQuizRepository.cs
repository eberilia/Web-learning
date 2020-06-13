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

        public Quiz AddQuiz(Quiz quiz)
        {
            context.Quizes.Add(quiz);
            context.SaveChanges();
            return quiz;
        }

        public Quiz DeteleQuiz(uint id)
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

        public List<Quiz> GetUsersQuizes(string username)
        {
            List<Quiz> allQuizes = GetAllQuizes().ToList();
            List<Quiz> usersQuizes = new List<Quiz>();

            for (int i = 0; i < allQuizes.Count; i++)
                if (allQuizes[i].UsernameFK.Equals(username))
                    usersQuizes.Add(allQuizes[i]);

            return usersQuizes;
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
