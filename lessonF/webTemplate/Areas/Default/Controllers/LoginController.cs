using System.Linq;
using System.Web.Mvc;
using webTemplate.App_LocalResources;
using webTemplate.Helpers;
using webTemplate.Models.ViewModels;
using webTemplate.Controllers;
using webTemplate.Models.ViewModels.User;
using webTemplate.Tools.Mail;

namespace webTemplate.Areas.Default.Controllers
{
    public class LoginController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add(new ModelError(GlobalRes.password_doesnt_match));
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordView());
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordView forgotPasswordView)
        {
            if (ModelState.IsValid)
            {
                var user =
                    Repository.Users.FirstOrDefault(p => string.Compare(p.Email, forgotPasswordView.Email, true) == 0);
                if (user != null)
                {
                    NotifyMail.SendNotify("ForgotPassword_" + CurrentLangCode, user.Email,
                                                format => string.Format(format, HostName),
                                                format => string.Format(format, CurrentLangCode, user.Email, user.Password, HostName));
                    return View("ForgotPasswordSuccess");
                }
                ModelState.AddModelError("Email", GlobalRes.email_user_not_found);
            }
            return View(forgotPasswordView);
        }
    }

}
