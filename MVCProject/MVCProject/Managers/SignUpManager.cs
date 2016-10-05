using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Managers
{
    

    public class SignUpManager
    {
        List<string> emailItems = new List<string> { "shawn@yahoo.com", "shawn@gmail.com" };

        public string ValidateEmail(string Email)
        {
            foreach (var item in emailItems)
            {
                if (Email == item )
                {
                    return "Email '" + Email + "' already exists";
                }                    
            }
            return "";
        }
        public string ValidateUsername(string Username)
        {
            if (Username == "Shawnrafael" || Username == "Rafaelshawn")
            {
                return "Username '" + Username + "' already exists";
            }
            else
            {
                return "";
            }
        }
        //public string ValidateUsername(string UserName) -- Faye:
        //{
        //    if (UserName == "FayePhoneee")
        //    {
        //        return "User Name already exists";
        //    }
        //    else
        //    {
        //        return "User Name Available";
        //    }
        //}

    }

    public class CustomValidationBirthdate : ValidationAttribute
    {
        int _minimumAge;
        int _maximumAge;

        public CustomValidationBirthdate(int minimumAge, int maximumAge)
        {
            _minimumAge = minimumAge;
            _maximumAge = maximumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            if (date == null)
            {
                return false;
            }
            if (date.AddYears(_minimumAge) > DateTime.Now)
            {
                return false;
            }
            return date.AddYears(_maximumAge) > DateTime.Now;

        }
    }
}