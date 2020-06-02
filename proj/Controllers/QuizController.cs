using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using proj.Models;


namespace proj.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuiz _quiz;
        private readonly IQuestion _question;
        private readonly IUser _user;

        public QuizController(IQuiz quiz, IQuestion question, IUser user)
        {
            _quiz = quiz;
            _question = question;
            _user = user;
        }

       

        public IActionResult Index()
        {
            List<Quiz> quizes = _quiz.GetAllQuizes().ToList();
            ViewBag.quizes = quizes;

            return View(quizes);
        }

        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateQuiz()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuiz(string submit, string quizname, string category,
            string q, string qa1, string qa1bool, string qa2, string qa2bool)
        {
            Quiz quiz = new Quiz();
            quiz.QuizName = quizname;
            quiz.Category = category;

            quiz.UsernameFK = DataStorage.CurrentlyLoggedInUsername;
            _quiz.AddQuiz(quiz);


            /* jakie Id ma nowy quiz? */
            List<Quiz> allQuizes = new List<Quiz>();
            allQuizes = _quiz.GetAllQuizes().ToList();
            uint idNewQuiz = allQuizes[allQuizes.Count - 1].IdQuiz;


            Question question = new Question();
            question.TextQuestion = q;
            question.IdQuizFK = idNewQuiz;

            question.Answer1 = qa1;

            if (qa1bool != null)
                question.Answer1Bool = true;
            else
                question.Answer1Bool = false;

            question.Answer2 = qa2;

            if (qa2bool != null)
                question.Answer2Bool = true;
            else
                question.Answer2Bool = false;

            question.Answer3Bool = false;
            question.Answer4Bool = false;
            question.Answer5Bool = false;
            question.Answer6Bool = false;
            question.Answer7Bool = false;
            question.Answer8Bool = false;

            _question.AddQuestion(question);

            if (submit.Equals("Dodaj następne pytanie"))
                return RedirectToAction("AddQuestion");
            else
                return RedirectToAction("Index");
        }

        public IActionResult Quiz(uint ID)
        {
            ViewData["ID"] = ID;


            Quiz q = _quiz.GetQuiz(ID);

            List<Question> allQuestions = _question.GetAllQuestions().ToList();
            List<Question> questions = new List<Question>();
            for(int i=0; i<allQuestions.Count; i++)
            {
                if(allQuestions[i].IdQuizFK == ID)
                {
                    questions.Add(allQuestions[i]);
                }

            }

            q.Questions = questions;
   
            return View(q);
        }

        public IActionResult Stats(uint ID)
        {

            Score sc = new Score();
            sc.IdQuiz = ID;

            Quiz q = _quiz.GetQuiz(ID);

            for (int i=0; i<Request.Form.ToList().Count - 1; i++)
            {
                string mess = "Q" + (i + 1);
                string a = Request.Form.ToList()[i].Value;
                ViewData[mess] = a;
                sc.UserAnswers.Add(a);
            }


            List<Question> allQuestions = _question.GetAllQuestions().ToList();
            List<Question> questions = new List<Question>();
            for (int i = 0; i < allQuestions.Count; i++)
            {
                if (allQuestions[i].IdQuizFK == ID)
                {
                    questions.Add(allQuestions[i]);
                }

            }

            q.Questions = questions;
            sc.Questions = questions;

            
            sc.CheckAnswers();


            return View(sc);
        }

          
    }
}
