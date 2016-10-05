using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class ContactModels
    {
        [Required(ErrorMessage = "{0} field is required")]
        [RegularExpression("([0-9])*", ErrorMessage = "{0} must numbers only.")]
        [StringLength(11, ErrorMessage = "Maximum length for {0} is 11 characters only.")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [RegularExpression("([0-9])*", ErrorMessage = "{0} must numbers only.")]
        [StringLength(7, ErrorMessage = "Maximum length for {0} is 7 characters only.")]
        [Display(Name = "Land Line")]
        public string LandLine { get; set; }

        [Required(ErrorMessage = "{0} field is required.")]
        [StringLength(30, ErrorMessage = "Maximum length for {0} is 30 characters only.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}