using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IdUser { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        public string Username { get; set; }

        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "Adresy e-mail nie są zgodne.")]
        [Required(ErrorMessage = "Powtórzenie adresu e-mail jest wymagane.")]
        [Display(Name = "Powtórz adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "Powtórzenie hasła jest wymagane.")]
        [Compare("Password", ErrorMessage = "Hasła nie są zgodne.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        
        public ICollection<Quiz> Quizes { get; set; }


    }
}
