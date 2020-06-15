using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

//using static proj.Models.Category;

namespace proj.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IdQuiz { get; set; }

        [Display(Name = "Nazwa quizu")]
        [Required(ErrorMessage = "Nazwa quizu jest wymagana.")]
        public string QuizName { get; set; }

        [Display(Name = "Kategoria")]
        //[DefaultValue(Models.Category.INNE)]
        /*D*/
        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        public string Category { get; set; }


      
        public ICollection<Question> Questions { get; set; }

        /*D*/
        
        [ForeignKey("UsernameFK")]
        public User User { get; set; }

        [Required]
        public string UsernameFK { get; set; }
        
        


        //public List<Question> Questions { get; set; }

        /*public Quiz()
        {
            Questions = new List<Question>();
        }

        public Quiz(uint idQuiz)
        {
            IdQuiz = idQuiz;
            Questions = new List<Question>();
        }*/
    }
}
