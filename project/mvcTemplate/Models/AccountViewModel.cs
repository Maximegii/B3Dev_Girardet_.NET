using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class AccountViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmedPassword { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }



    }
}