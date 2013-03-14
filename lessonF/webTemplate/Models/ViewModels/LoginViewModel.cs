using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using webTemplate.App_LocalResources;

namespace webTemplate.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "enter_email", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "enter_password", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}