using System.ComponentModel.DataAnnotations;

namespace EduEvent.Models
{
    public class AccountViewModel
    {
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [Display(Name = "Confirmer votre Mot de passe")]
        public string ConfirmedPassword { get; set; }
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }
        [Display(Name = "Nom")]
        public string Lastname { get; set; }



    }
}