using System.ComponentModel.DataAnnotations;
using webTemplate.App_LocalResources;
using webTemplate.Attributes.Validation;

namespace webTemplate.Models.ViewModels.User
{
    public class ForgotPasswordView
    {
        [Required(ErrorMessageResourceName = "enter_email", ErrorMessageResourceType = typeof(GlobalRes))]
        [ValidEmail(ErrorMessageResourceName = "enter_correct_email", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }
    }
}