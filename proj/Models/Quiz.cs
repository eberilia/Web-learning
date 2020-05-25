using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Question
    {
        [DisplayName("Pytanie")]
        [StringLength(60, ErrorMessage = "Pytanie nie może być dłuższe niż 60 znaków")]
        public string Pyt { get; set; }

        [DisplayName("Odpowiedź")]
        [StringLength(30, ErrorMessage = "Nazwisko nie może być dłuższe niż 30 znaków")]
        public string Odp { get; set; }

        [DisplayName("Odpowiedź1")]
        [StringLength(30, ErrorMessage = "Nazwisko nie może być dłuższe niż 30 znaków")]
        public string Odp1 { get; set; }

        [DisplayName("Odpowiedź2")]
        [StringLength(30, ErrorMessage = "Nazwisko nie może być dłuższe niż 30 znaków")]
        public string Odp2 { get; set; }
        [DisplayName("Odpowiedź3")]
        [StringLength(30, ErrorMessage = "Nazwisko nie może być dłuższe niż 30 znaków")]
        public string Odp3 { get; set; }
    }
}
