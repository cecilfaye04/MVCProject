using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CredentialModels
    {
        [Required(ErrorMessage = "*{0} field is required.")]
        [EmailAddress(ErrorMessage = "*Please type a proper {0}. (e.g. 'email@gmail.com')")]
        [StringLength(64, ErrorMessage = "*EmailAddress is too long.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*{0} field is required.")]
        [RegularExpression("(?=.{8,})([a-zA-Z])*", ErrorMessage = "*{0} must be at least 8 characters long and must not contain any numbers or any special characters.")]
        [StringLength(240, ErrorMessage = "*Username is too long.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*{0} field is required.")]
        //[RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[`!%$&^*()]).*$", ErrorMessage = "{0} must be at least 8 characters long and must contain atleast one specialcase character, one lowercase and one uppercase.")]
        [StringLength(15, ErrorMessage = "*Maximum length for {0} is 15 characters only.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*{0} field is required.")]
        [Compare("Password", ErrorMessage = "*{0} do not match the Password typed above.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassord { get; set; }
    }
}