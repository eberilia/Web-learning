using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class SQLQuestionRepository : IQuestion
    {
        private readonly AppDbContext context;
        public SQLQuestionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Question AddQuestion(Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
            return question;
        }

        public Question DeteleQuestion(int id)
        {
            Question q = context.Questions.Find(id);
            if (q != null)
            {
                context.Questions.Remove(q);
                context.SaveChanges();
            }
            return q;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return context.Questions;
        }

        public Question GetQuestion(int Id)
        {
            return context.Questions.Find(Id);
        }

        public Question UpdateQuestion(Question questionChange)
        {
            var q = context.Questions.Attach(questionChange);
            q.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return questionChange;
        }
    }
}
