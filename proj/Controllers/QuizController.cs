using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using proj.Models;


namespace proj.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quiz(uint ID)
        {
            ViewData["ID"] = ID;

             // TO DO - odszukaj quizu o id w bazie i stworz nowa zmienna Quiz o tych parametrach

            Quiz q = new Quiz();
            q.Questions = new List<Question>();
            
            /* Tworzenie pytania */
            Question x = new Question();
            x.TextAnswers = new List<string>();
            x.Answers = new List<bool>();

            x.TextQuestion = "Ile stopni ma kat prosty?";

            x.TextAnswers.Add("60");
            x.TextAnswers.Add("120");
            x.TextAnswers.Add("90");

            x.Answers.Add(false);
            x.Answers.Add(false);
            x.Answers.Add(true);

            /* Dodanie pytania do Quizu*/
            q.Questions.Add(x);


            Question y = new Question();
            y.TextAnswers = new List<string>();
            y.Answers = new List<bool>();

            y.TextQuestion = "Kolor rozowy powstaje z polaczenia kolorow: ";

            y.TextAnswers.Add("Czerwonego i bialego");
            y.TextAnswers.Add("Zielonego i zoltego");
            y.TextAnswers.Add("Niebieskiego i czarnego");
            y.TextAnswers.Add("Pomaranczowego i czerwonego");

            y.Answers.Add(true);
            y.Answers.Add(false);
            y.Answers.Add(false);
            y.Answers.Add(false);

            q.Questions.Add(y);

            return View(q);
        }

        public IActionResult Stats(string q1, string q2)
        {
            ViewData["Q1"] = q1;
            ViewData["Q2"] = q2;

            return View();
        }

        

    }
}
