using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Question
    {

        public string TextQuestion { get; set; }
        public List<string> TextAnswers { get; set; }
        public List<bool> Answers { get; set; }

        public Question()
        {
            TextAnswers = new List<string>();
            Answers = new List<bool>();
        }

        /*public Dictionary<string, bool> odp { get; set; }
           
        public static void Main(string[] args)
        {
            Question q = new Question();

            q.odp = new Dictionary<string, bool>();

            q.odp.Add("OPCJA 1", false);
            q.odp.Add("OPCJA 2", true);

            Console.WriteLine(q.odp);

            foreach( var opcja in q.odp)
            {
                Console.WriteLine("KLUCZ: " + opcja.Key + " WARTOSC: " + opcja.Value);
            }

        }*/




    }
}
