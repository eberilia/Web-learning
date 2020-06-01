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

        public QuizController(IQuiz quiz, IQuestion question)
        {
            _quiz = quiz;
            _question = question;
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
        public IActionResult CreateQuiz(string submit, string quizname, string category)
        {
            Quiz q = new Quiz();
            q.QuizName = quizname;
            q.Category = category;

            q.UsernameFK = DataStorage.CurrentlyLoggedInUsername;

            _quiz.AddQuiz(q);

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
