using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public interface IQuiz
    {
        Quiz GetQuiz(int id);
        IEnumerable<Quiz> GetAllQuizes();
        Quiz AddQuiz(Quiz quiz);
        Quiz UpdateQuiz(Quiz quizChange);
        Quiz DeteleQuiz(int id);
    }
}
