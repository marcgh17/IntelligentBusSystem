using System.ComponentModel.DataAnnotations;
namespace IntelligentBusSystem.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation must match!")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "First name is Required")]
        [Display(Name = "Last Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

    }
}