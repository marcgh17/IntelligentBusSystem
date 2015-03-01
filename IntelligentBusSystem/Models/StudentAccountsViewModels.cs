using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace IntelligentBusSystem.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage = "ID is Required")]
        [Display(Name = "ID")]
        public string ID { get; set; }


        [Required(ErrorMessage = "First name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Birthdate is Required")]
        [Display(Name = "Birthdate")]
        public string Birthdate { get; set; }

        [Required(ErrorMessage = "StudentClass is Required")]
        [Display(Name = "StudentClass")]
        public int StudentClassID { get; set; }

        [Required(ErrorMessage = "StudentAddresses is Required")]
        [Display(Name = "StudentAddresses")]
        public string StudentAddresses { get; set; }

        public List<Subscription> StudentSubscriptions { get; set; }
        public List<Class> AllClasses { get; set; }

        public School School { get; set; }
      
    }
}