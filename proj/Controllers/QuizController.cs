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
        public IActionResult AddQuestion(uint id, string submit, string type_question, string q,
            string qa1, string qa2, string qa3, string qa4,
            string qa5, string qa6, string qa7, string qa8, string [] qbool)
        {

            Question question = new Question();
            question.TextQuestion = q;
            question.IdQuizFK = id;
            question.QuestionType = type_question;

            question.Answer1 = qa1;
            question.Answer2 = qa2;

            if (qa3 != null) question.Answer3 = qa3;
            if (qa4 != null) question.Answer4 = qa4;
            if (qa5 != null) question.Answer5 = qa5;
            if (qa6 != null) question.Answer6 = qa6;
            if (qa7 != null) question.Answer7 = qa7;
            if (qa8 != null) question.Answer8 = qa8;

            for (int i = 0; i < qbool.Length; i++)
            {

                if (qbool[i].ElementAt(1) == '1')
                    question.Answer1Bool = true;

                else if (qbool[i].ElementAt(1) == '2')
                    question.Answer2Bool = true;

                else if (qbool[i].ElementAt(1) == '3')
                    question.Answer3Bool = true;

                else if (qbool[i].ElementAt(1) == '4')
                    question.Answer4Bool = true;

                else if (qbool[i].ElementAt(1) == '5')
                    question.Answer5Bool = true;

                else if (qbool[i].ElementAt(1) == '6')
                    question.Answer6Bool = true;

                else if (qbool[i].ElementAt(1) == '7')
                    question.Answer7Bool = true;

                else if (qbool[i].ElementAt(1) == '8')
                    question.Answer8Bool = true;

            }


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
            string type_question, string q,
            string qa1, string qa2, string qa3, string qa4,
            string qa5, string qa6, string qa7, string qa8, string [] qbool)
        {

            //System.Diagnostics.Debug.WriteLine(type);

            Quiz quiz = new Quiz();
            quiz.QuizName = quizname;
            quiz.Category = category;

            quiz.UsernameFK = DataStorage.CurrentlyLoggedInUsername;
            _quiz.AddQuiz(quiz);


            List<Quiz> usersQuizes = _quiz.GetUsersQuizes(DataStorage.CurrentlyLoggedInUsername);
            uint actualIdQuiz = usersQuizes[usersQuizes.Count - 1].IdQuiz;


            Question question = new Question();
            question.TextQuestion = q;
            question.QuestionType = type_question;
            question.IdQuizFK = actualIdQuiz;

            question.Answer1 = qa1;
            question.Answer2 = qa2;

            if (qa3 != null) question.Answer3 = qa3;
            if (qa4 != null) question.Answer4 = qa4;
            if (qa5 != null) question.Answer5 = qa5;
            if (qa6 != null) question.Answer6 = qa6;
            if (qa7 != null) question.Answer7 = qa7;
            if (qa8 != null) question.Answer8 = qa8;


            for(int i=0; i<qbool.Length; i++)
            {

                if (qbool[i].ElementAt(1) == '1')
                    question.Answer1Bool = true;

                else if (qbool[i].ElementAt(1) == '2')
                    question.Answer2Bool = true;

                else if (qbool[i].ElementAt(1) == '3')
                    question.Answer3Bool = true;

                else if (qbool[i].ElementAt(1) == '4')
                    question.Answer4Bool = true;

                else if (qbool[i].ElementAt(1) == '5')
                    question.Answer5Bool = true;

                else if (qbool[i].ElementAt(1) == '6')
                    question.Answer6Bool = true;

                else if (qbool[i].ElementAt(1) == '7')
                    question.Answer7Bool = true;

                else if (qbool[i].ElementAt(1) == '8')
                    question.Answer8Bool = true;

            }


           
            _question.AddQuestion(question);

            if (submit.Equals("Dodaj następne pytanie"))
                return RedirectToAction("AddQuestion", new { @id = actualIdQuiz});
            else
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult EditQuiz(uint id)
        {
            Quiz quiz = new Quiz();
            quiz = _quiz.GetQuiz(id);
            //System.Diagnostics.Debug.WriteLine(id);
            return View(quiz);

        }

        [HttpPost]
        public IActionResult EditQuiz(string submit, string quizname, string category,
            string type_question, string q,
            string qa1, string qa2, string qa3, string qa4,
            string qa5, string qa6, string qa7, string qa8, string[] qbool)
        {

            //System.Diagnostics.Debug.WriteLine(type);

            Quiz quiz = new Quiz();
            quiz.QuizName = quizname;
            quiz.Category = category;

            quiz.UsernameFK = DataStorage.CurrentlyLoggedInUsername;
            _quiz.AddQuiz(quiz);


            List<Quiz> usersQuizes = _quiz.GetUsersQuizes(DataStorage.CurrentlyLoggedInUsername);
            uint actualIdQuiz = usersQuizes[usersQuizes.Count - 1].IdQuiz;


            Question question = new Question();
            question.TextQuestion = q;
            question.QuestionType = type_question;
            question.IdQuizFK = actualIdQuiz;

            question.Answer1 = qa1;
            question.Answer2 = qa2;

            if (qa3 != null) question.Answer3 = qa3;
            if (qa4 != null) question.Answer4 = qa4;
            if (qa5 != null) question.Answer5 = qa5;
            if (qa6 != null) question.Answer6 = qa6;
            if (qa7 != null) question.Answer7 = qa7;
            if (qa8 != null) question.Answer8 = qa8;


            for (int i = 0; i < qbool.Length; i++)
            {

                if (qbool[i].ElementAt(1) == '1')
                    question.Answer1Bool = true;

                else if (qbool[i].ElementAt(1) == '2')
                    question.Answer2Bool = true;

                else if (qbool[i].ElementAt(1) == '3')
                    question.Answer3Bool = true;

                else if (qbool[i].ElementAt(1) == '4')
                    question.Answer4Bool = true;

                else if (qbool[i].ElementAt(1) == '5')
                    question.Answer5Bool = true;

                else if (qbool[i].ElementAt(1) == '6')
                    question.Answer6Bool = true;

                else if (qbool[i].ElementAt(1) == '7')
                    question.Answer7Bool = true;

                else if (qbool[i].ElementAt(1) == '8')
                    question.Answer8Bool = true;

            }

            _question.AddQuestion(question);

            if (submit.Equals("Dodaj następne pytanie"))
                return RedirectToAction("AddQuestion", new { @id = actualIdQuiz });
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

            Score sc = new Score(ID, _question.GetQuestionsWithQuizId(ID));

            for (int i = 0; i < Request.Form.ToList().Count - 1; i++)
            {
                //string mess = "Q" + (i + 1);
                string[] val = Request.Form.ToList()[i].Value;
                uint key = (uint)i + 1;
                for (int j = 0; j < val.Length; j++)
                    sc.AddToUserAnswers(key, val[j]);
                //ViewData[mess] = a;
                //sc.UserAnswers.Add(a);
            }



            sc.CheckAnswers();
            return View(sc);
        }


    }
}
