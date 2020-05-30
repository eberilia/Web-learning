using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public interface IQuestion
    {
        Question GetQuestion(int Id);
        IEnumerable<Question> GetAllQuestions();
        Question AddQuestion(Question question);
        Question UpdateQuestion(Question questionChange);
        Question DeteleQuestion(int id);
    }
}
