using GenerateData;
using LessonProject.Model;
using LessonProject.Models.ViewModels;
using LessonProject.Tools;
using LessonProject.UnitTest.Mock.Http;
using LessonProject.UnitTest.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace LessonProject.IntegrationTest
{
    [TestFixture]
    public class DefaultUserControllerTest
    {
        [Test]
        public void CreateUser_CreateNormalUser_CountPlusOne()
        {
            var repository = DependencyResolver.Current.GetService<IRepository>();

            var controller = DependencyResolver.Current.GetService<LessonProject.Areas.Default.Controllers.UserController>();

            var countBefore = repository.Users.Count();
            var httpContext = new MockHttpContext().Object;

            var route = new RouteData();

            route.Values.Add("controller", "User");
            route.Values.Add("action", "Register");
            route.Values.Add("area", "Default");

            ControllerContext context = new ControllerContext(new RequestContext(httpContext, route), controller);
            controller.ControllerContext = context;

            controller.Session.Add(CaptchaImage.CaptchaValueKey, "1111");

            var registerUserView = new UserView()
            {
                ID = 0,
                Email = "chernikov@googlemail.com",
                Password = "123456",
                ConfirmPassword = "123456",
                Captcha = "1111",
                BirthdateDay = 13,
                BirthdateMonth = 9,
                BirthdateYear = 1970
            };

            Validator.ValidateObject<UserView>(registerUserView);
            controller.Register(registerUserView);

            var countAfter = repository.Users.Count();
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        [Test]
        public void CreateUser_Create100Users_NoAssert()
        {
            var repository = DependencyResolver.Current.GetService<IRepository>();
            var controller = DependencyResolver.Current.GetService<LessonProject.Areas.Default.Controllers.UserController>();

            var httpContext = new MockHttpContext().Object;

            var route = new RouteData();

            route.Values.Add("controller", "User");
            route.Values.Add("action", "Register");
            route.Values.Add("area", "Default");

            ControllerContext context = new ControllerContext(new RequestContext(httpContext, route), controller);
            controller.ControllerContext = context;

            controller.Session.Add(CaptchaImage.CaptchaValueKey, "1111");

            var rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 100; i++)
            {
                var registerUserView = new UserView()
                {
                    ID = 0,
                    Email = Email.GetRandom(Name.GetRandom(), Surname.GetRandom()),
                    Password = "123456",
                    ConfirmPassword = "123456",
                    Captcha = "1111",
                    BirthdateDay = rand.Next(28) + 1,
                    BirthdateMonth = rand.Next(12) + 1,
                    BirthdateYear = 1970 + rand.Next(20)
                };
                 controller.Register(registerUserView);
            }
        }
    }
}
