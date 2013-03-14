using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using webTemplate.App_LocalResources;
using webTemplate.Attributes.Validation;

namespace webTemplate.Models.ViewModels.User
{
    public class ChangePasswordView
    {
        public int ID { get; set; }

        [IsUserPassword(ErrorMessageResourceName = "not_valid_password", ErrorMessageResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "enter_password", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "enter_new_password", ErrorMessageResourceType = typeof(GlobalRes))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceName = "enter_confirm_password", ErrorMessageResourceType = typeof(GlobalRes))]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessageResourceName = "password_doesnt_match", ErrorMessageResourceType = typeof(GlobalRes))]
        public string ConfirmPassword { get; set; }
    }
}