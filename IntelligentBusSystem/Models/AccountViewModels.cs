using System.ComponentModel.DataAnnotations;

namespace IntelligentBusSystem.Models
{
   

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

   
}
