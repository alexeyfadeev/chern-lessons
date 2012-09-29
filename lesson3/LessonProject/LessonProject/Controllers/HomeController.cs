using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Models;
using Ninject;

namespace LessonProject.Controllers
{
    public class HomeController : Controller
    {
        private IWeapon weapon { get; set; }

        public HomeController()
        {
            weapon = DependencyResolver.Current.GetService<IWeapon>();
        }

        public ActionResult Index()
        {
            return View(weapon);
        }
    }
}
