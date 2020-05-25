﻿using System;
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

            return View(q);
        }

        public IActionResult Stats(string q1, string q2)
        {
            ViewData["Q1"] = q1;
            ViewData["Q2"] = q2;


            // string id quizu pobrane z formularza
            // Score sc = new Score(String ID formularza);
            // Score -> czytanie z bazy danych poprawnych odp
            // sc.generateScore([])
            // return view(sc)
            //

            Score sc = new Score();

            if(q1.Equals("90"))
            {
                sc.UserCorrectnessAnswers.Add(true);
            }
            else
            {
                sc.UserCorrectnessAnswers.Add(false);
            }

            if(q2.Equals("Czerwonego i bialego"))
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
