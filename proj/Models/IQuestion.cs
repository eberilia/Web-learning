using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public interface IQuestion
    {
        Question GetQuestion(uint Id);
        IEnumerable<Question> GetAllQuestions();
        Question AddQuestion(Question question);
        Question UpdateQuestion(Question questionChange);
        Question DeleteQuestion(uint id);
        List<Question> GetQuestionsWithQuizId(uint id);
    }
}
