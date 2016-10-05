using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.ViewModels
{
    public class ViewModel
    {
        public ContactModels allContactInfo { get; set; }
        public CredentialModels allCredentialInfo { get; set; }
        public BasicModels allBasicInfo { get; set; }
    }
}