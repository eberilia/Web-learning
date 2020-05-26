using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
             //baza danych zwroc mi obiekt typu quiz o id takim
             // quiz q = pobierz z bazy

            Quiz q = new Quiz();
            q.IdQuiz = ID;
            
            /* Tworzenie pytania */
            Question x = new Question();
       
            x.TextQuestion = "Ile stopni ma kat prosty?";

            x.Answers.Add("60", false);
            x.Answers.Add("120", false);
            x.Answers.Add("90", true);
          
            q.Questions.Add(x);


            Question y = new Question();
            
            y.TextQuestion = "Kolor rozowy powstaje z polaczenia kolorow: ";

            y.Answers.Add("Czerwonego i bialego", true);
            y.Answers.Add("Zielonego i zoltego", false);
            y.Answers.Add("Niebieskiego i czarnego", false);
            y.Answers.Add("Pomaranczowego i czerwonego", false);

            q.Questions.Add(y);

            Question z = new Question();

            z.TextQuestion = "Bblablbalblbblablba?";

            z.Answers.Add("Ababababa", true);
            z.Answers.Add("Hababababbaba?", false);
            z.Answers.Add("ablablblaabalaaaaaaaaaaaa", false);
            z.Answers.Add("bla?", false);

            q.Questions.Add(z);

            return View(q);
        }

        public IActionResult Stats()
        {

            for(int i=0; i<Request.Form.ToList().Count - 1; i++)
            {
                string mess = "Q" + (i + 1);
                string a = Request.Form.ToList()[i].Value;
                ViewData[mess] = a;
            }

            /*string q1 = Request.Form.ToList()[0].Value;
            string q2 = Request.Form.ToList()[1].Value;

            ViewData["Q1"] = q1;
            ViewData["Q2"] = q2;*/


            // string id quizu pobrane z formularza
            // Score sc = new Score(String ID formularza);
            // Score -> czytanie z bazy danych poprawnych odp
            // sc.generateScore([])
            // return view(sc)
            //

            
            Score sc = new Score();



            if(Request.Form.ToList()[0].Value.Equals("90"))
            {
                sc.UserCorrectnessAnswers.Add(true);
            }
            else
            {
                sc.UserCorrectnessAnswers.Add(false);
            }

            if(Request.Form.ToList()[1].Value.Equals("Czerwonego i bialego"))
            {
                sc.UserCorrectnessAnswers.Add(true);
            }
            else
            {
                sc.UserCorrectnessAnswers.Add(false);
            }
            if(Request.Form.ToList()[2].Value.Equals("Hababababbaba?"))
            {
                sc.UserCorrectnessAnswers.Add(true);
            }
            else
            {
                sc.UserCorrectnessAnswers.Add(false);
            }


            return View(sc);
        }

        

    }
}
