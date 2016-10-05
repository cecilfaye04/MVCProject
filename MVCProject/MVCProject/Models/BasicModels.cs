using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class BasicModels
    {
        [Required(ErrorMessage = "{0} field is required.")]
        [RegularExpression("([a-zA-Z])*", ErrorMessage = "{0} must not contain any numbers or any special characters.")]
        [StringLength(15, ErrorMessage = "Maximum length for {0} is 15 characters only.")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} field is required.")]
        [RegularExpression("([a-zA-Z])*", ErrorMessage = "{0} must not contain any numbers or any special characters.")]
        [StringLength(15, ErrorMessage = "Maximum length for {0} is 15 characters only.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} field is required.")]
        //[CustomValidationBirthdate(12, 60, ErrorMessage = "Age must be between 12 and 60.")]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public int Age
        {
            get
            {
                var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                var dob = float.Parse(Birthdate.ToString("yyyy.MMdd"));
                return (int)(now - dob);
            }
           
        }
        public string Gender { get; set; }

        //[Required(ErrorMessage = "Please provide a {0}.")]
        [Display(Name = "Profile Picture")]
        public string PictureName { get; set; }
    }
}