using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace proj.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IdQuestion { get; set; }

        [Display(Name = "Treść pytania")]
        [Required(ErrorMessage = "Treść pytania jest wymagana.")]
        public string TextQuestion { get; set; }

        [Display(Name = "Typ pytania")]
        [Required(ErrorMessage = "Typ pytania jest wymagany.")]
        public string QuestionType { get; set; }

        [Display(Name = "Odpowiedź 1")]
        [Required(ErrorMessage = "Treść odpowiedzi jest wymagana.")]
        public string Answer1 { get; set; }

        [Display(Name = "Prawidłowa?")]
        public bool? Answer1Bool { get; set; }

        [Display(Name = "Odpowiedź 2")]
        [Required(ErrorMessage = "Treść odpowiedzi jest wymagana.")]
        public string Answer2 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer2Bool { get; set; }

        [Display(Name = "Odpowiedź 3")]
        public string Answer3 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer3Bool { get; set; }

        [Display(Name = "Odpowiedź 4")]
        public string Answer4 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer4Bool { get; set; }

        [Display(Name = "Odpowiedź 5")]
        public string Answer5 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer5Bool { get; set; }

        [Display(Name = "Odpowiedź 6")]
        public string Answer6 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer6Bool { get; set; }

        [Display(Name = "Odpowiedź 7")]
        public string Answer7 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer7Bool { get; set; }

        [Display(Name = "Odpowiedź 8")]
        public string Answer8 { get; set; }
        [Display(Name = "Prawidłowa?")]
        public bool? Answer8Bool { get; set; }


        [ForeignKey("IdQuizFK")]
        public Quiz Quiz { get; set; }

        [Required]
        public uint IdQuizFK { get; set; }
        
        

        //public Dictionary<string, bool> Answers;
        //public List<string> Answers_text;
        //public List<bool> Answers_bool;

       /* public Question(int id, string textQuestion)
        {
            //Answers = new Dictionary<string, bool>();
            Answers_text = new List<string>();
            Answers_bool = new List<bool>();
        }*/

    }
}
