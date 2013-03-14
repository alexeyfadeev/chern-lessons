using System.Web.Mvc;
using webTemplate.Areas.Admin.Models.View;

namespace webTemplate.Areas.Admin.Controllers
{
    [Authorize(Roles="admin,moderator")]
    public class HomeController : AdminController
    {
       public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminMenu()
        {
            return View();
        }

        public ActionResult LangMenu()
        {
            LangAdminView langProxy = new LangAdminView(Repository, CurrentLang.Code);
            return View(langProxy);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(string selectedLang)
        {
            Repository.ChangeLanguage(CurrentUser, selectedLang);
            return  Redirect(Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "~/admin");
        }
    }
}
