using System.ComponentModel.DataAnnotations;
using ManageAttribute;
using webTemplate.App_LocalResources;
using webTemplate.Attributes.Validation;

namespace webTemplate.Models.ViewModels.User
{
    public class BaseUserView
    {
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "enter_email", ErrorMessageResourceType = typeof(GlobalRes))]
        [ValidEmail(ErrorMessageResourceName = "enter_correct_email", ErrorMessageResourceType = typeof(GlobalRes))]
        [UserEmailValidation(ErrorMessageResourceName = "email_already_registered", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }
    }
}