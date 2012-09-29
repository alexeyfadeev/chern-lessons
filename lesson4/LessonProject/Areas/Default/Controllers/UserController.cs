using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {
        public ActionResult Index()
        {
            var users = Repository.Users.ToList();
            return View(users);
        }

    }
}
