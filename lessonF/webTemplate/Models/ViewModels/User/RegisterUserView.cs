using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using webTemplate.App_LocalResources;
using webTemplate.Model;
using webTemplate.Attributes.Validation;

namespace webTemplate.Models.ViewModels.User
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessageResourceName = "password_doesnt_match", ErrorMessageResourceType = typeof(GlobalRes))]
    public class RegisterUserView : BaseUserView
    {
        [Required(ErrorMessageResourceName = "enter_password", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "confirm_password_error", ErrorMessageResourceType = typeof(GlobalRes))]
        [System.Web.Mvc.Compare("Password", ErrorMessageResourceName = "password_doesnt_match", ErrorMessageResourceType = typeof(GlobalRes))]
        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }
    }
}