using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTemplate.Models.ViewModels;
using webTemplate.Model;
using webTemplate.Models.ViewModels.User;
using webTemplate.Model;


namespace webTemplate.Areas.Admin.Controllers
{ 
    [Authorize(Roles="admin")]
    public class UserController : AdminController
    {
		public ActionResult Index(int page = 1)
        {
            var list = Repository.Users.OrderBy(p => p.ID);
			var data = new PageableData<User>();
			data.Init(list, page, "Index");
			data.List.ForEach(p => p.CurrentLang = CurrentLang.ID);
			return View(data);
		}

		public ActionResult Create() 
		{
			var userView = new UserView();
			userView.CurrentLang = CurrentLang.ID;
			return View("Edit", userView);
		}

		[HttpGet]
		public ActionResult Edit(int id) 
		{
			var  user = Repository.Users.FirstOrDefault(p => p.ID == id); 

			if (user != null) {
			user.CurrentLang = CurrentLang.ID;
				var userView = (UserView)ModelMapper.Map(user, typeof(User), typeof(UserView));
				return View(userView);
			}
			return RedirectToNotFoundPage;
		}

		[HttpPost]
		public ActionResult Edit(UserView userView)
        {
            if (ModelState.IsValid)
            {
                var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));
			user.CurrentLang = CurrentLang.ID;
                if (user.ID == 0)
                {
                    Repository.CreateUser(user);
                }
                else
                {
                    Repository.UpdateUser(user);
                }
                return RedirectToAction("Index");
            }
            return View(userView);
        }
	}
}