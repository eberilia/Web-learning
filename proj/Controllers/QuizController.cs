using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        [HttpGet]
        public IActionResult AddQuestion(uint id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(uint id, string submit, string q, string qa1, string qa1bool, string qa2, string qa2bool,
            string qa3, string qa3bool, string qa4, string qa4bool,
            string qa5, string qa5bool, string qa6, string qa6bool,
            string qa7, string qa7bool, string qa8, string qa8bool)
        {


            Question question = new Question();
            question.TextQuestion = q;
            question.IdQuizFK = id;

            question.Answer1 = qa1;
            question.Answer2 = qa2;

            if (qa3 != null) question.Answer3 = qa3;
            if (qa4 != null) question.Answer4 = qa4;
            if (qa5 != null) question.Answer5 = qa5;
            if (qa6 != null) question.Answer6 = qa6;
            if (qa7 != null) question.Answer7 = qa7;
            if (qa8 != null) question.Answer8 = qa8;

            if (qa1bool != null)
                question.Answer1Bool = true;
            else
                question.Answer1Bool = false;

            if (qa2bool != null)
                question.Answer2Bool = true;
            else
                question.Answer2Bool = false;

            if (qa3bool != null)
                question.Answer3Bool = true;
            else
                question.Answer3Bool = false;

            if (qa4bool != null)
                question.Answer4Bool = true;
            else
                question.Answer4Bool = false;

            if (qa5bool != null)
                question.Answer5Bool = true;
            else
                question.Answer5Bool = false;

            if (qa6bool != null)
                question.Answer6Bool = true;
            else
                question.Answer6Bool = false;

            if (qa7bool != null)
                question.Answer7Bool = true;
            else
                question.Answer7Bool = false;

            if (qa8bool != null)
                question.Answer8Bool = true;
            else
                question.Answer8Bool = false;


            _question.AddQuestion(question);


            if (submit.Equals("Dodaj następne pytanie"))
                return RedirectToAction("AddQuestion", new { @id = id });
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateQuiz()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuiz(string submit, string quizname, string category,
            string type, string q, string qa1, string qa1bool, string qa2, string qa2bool,
            string qa3, string qa3bool, string qa4, string qa4bool,
            string qa5, string qa5bool, string qa6, string qa6bool,
            string qa7, string qa7bool, string qa8, string qa8bool)
        {

            System.Diagnostics.Debug.WriteLine(type);

            Quiz quiz = new Quiz();
            quiz.QuizName = quizname;
            quiz.Category = category;

            quiz.UsernameFK = DataStorage.CurrentlyLoggedInUsername;
            _quiz.AddQuiz(quiz);


            List<Quiz> usersQuizes = _quiz.GetUsersQuizes(DataStorage.CurrentlyLoggedInUsername);
            uint actualIdQuiz = usersQuizes[usersQuizes.Count - 1].IdQuiz;


            Question question = new Question();
            question.TextQuestion = q;
            question.QuestionType = type;
            question.IdQuizFK = actualIdQuiz;

            question.Answer1 = qa1;
            question.Answer2 = qa2;

            if (qa3 != null) question.Answer3 = qa3;
            if (qa4 != null) question.Answer4 = qa4;
            if (qa5 != null) question.Answer5 = qa5;
            if (qa6 != null) question.Answer6 = qa6;
            if (qa7 != null) question.Answer7 = qa7;
            if (qa8 != null) question.Answer8 = qa8;

            if (qa1bool != null)
                question.Answer1Bool = true;
            else
                question.Answer1Bool = false;

            if (qa2bool != null)
                question.Answer2Bool = true;
            else
                question.Answer2Bool = false;

            if (qa3bool != null)
                question.Answer3Bool = true;
            else
                question.Answer3Bool = false;

            if (qa4bool != null)
                question.Answer4Bool = true;
            else
                question.Answer4Bool = false;

            if (qa5bool != null)
                question.Answer5Bool = true;
            else
                question.Answer5Bool = false;

            if (qa6bool != null)
                question.Answer6Bool = true;
            else
                question.Answer6Bool = false;

            if (qa7bool != null)
                question.Answer7Bool = true;
            else
                question.Answer7Bool = false;

            if (qa8bool != null)
                question.Answer8Bool = true;
            else
                question.Answer8Bool = false;

           
            _question.AddQuestion(question);

            if (submit.Equals("Dodaj następne pytanie"))
                return RedirectToAction("AddQuestion", new { @id = actualIdQuiz});
            else
                return RedirectToAction("Index");
            
        }

        public IActionResult Quiz(uint ID)
        {
            ViewData["ID"] = ID;

            Quiz q = _quiz.GetQuiz(ID);

            List<Question> questions = _question.GetQuestionsWithQuizId(ID);

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


            List<Question> questions = _question.GetQuestionsWithQuizId(ID);

            q.Questions = questions;
            sc.Questions = questions;

            
            sc.CheckAnswers();

            return View(sc);
        }

          
    }
}
