using LessonProject.Areas.Default.Controllers;
using LessonProject.Model;
using LessonProject.Models.Info;
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

namespace LessonProject.UnitTest
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void Register_GetView_ItsOkViewModelIsUserView()
        {
            Console.WriteLine("=====INIT======");
            var controller = new UserController();
            Console.WriteLine("======ACT======");
            var result = controller.Register();
            Console.WriteLine("====ASSERT=====");
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<UserView>(((ViewResult)result).Model);
        }

        [Test]
        public void Index_GetPageableDataOfUsers_CountOfUsersIsTwo()
        {
            //init
            var controller = DependencyResolver.Current.GetService<Areas.Default.Controllers.UserController>();
            //act
            var result = controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<PageableData<User>>(((ViewResult)result).Model);
            var count = ((PageableData<User>)((ViewResult)result).Model).List.Count();

            Assert.AreEqual(2, count);
        }

        [Test]
        public void Index_RegisterUserWithDifferentPassword_ExceptionCompare()
        {
            //init
            var controller = DependencyResolver.Current.GetService<Areas.Default.Controllers.UserController>();
            var httpContext = new MockHttpContext().Object;
            ControllerContext context = new ControllerContext(new RequestContext(httpContext,  new RouteData()), controller);
            controller.ControllerContext = context;

            //act
            var registerUserView = new UserView()
            {
                Email = "user@sample.com",
                Password = "123456",
                ConfirmPassword = "1234567",
                AvatarPath = "/file/no-image.jpg",
                BirthdateDay = 1,
                BirthdateMonth = 12,
                BirthdateYear = 1987,
                Captcha = "1111"
            };
            try
            {
                Validator.ValidateObject<UserView>(registerUserView);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidatorException>(ex);
                Assert.IsInstanceOf<System.ComponentModel.DataAnnotations.CompareAttribute>(((ValidatorException)ex).Attribute);
            }
        }

        [Test]
        public void Index_RegisterUserWithWrongCaptcha_ModelStateWithError()
        {
            //init
            var controller = DependencyResolver.Current.GetService<Areas.Default.Controllers.UserController>();
            var httpContext = new MockHttpContext().Object;
            ControllerContext context = new ControllerContext(new RequestContext(httpContext, new RouteData()), controller);
            controller.ControllerContext = context;
            controller.Session.Add(CaptchaImage.CaptchaValueKey, "2222");
            //act
            var registerUserView = new UserView()
            {
                Email = "user@sample.com",
                Password = "123456",
                ConfirmPassword = "1234567",
                AvatarPath = "/file/no-image.jpg",
                BirthdateDay = 1,
                BirthdateMonth = 12,
                BirthdateYear = 1987,
                Captcha = "1111"
            };

            var result = controller.Register(registerUserView);
            Assert.AreEqual("Текст с картинки введен неверно", controller.ModelState["Captcha"].Errors[0].ErrorMessage);
        }
    }
}
