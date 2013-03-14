using LessonProject.Global.Auth;
using LessonProject.UnitTest.Fake;
using LessonProject.UnitTest.Mock.Http;
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
    public class AdminHomeControllerTest
    {
        [Test]
        public void Index_NotAuthorizeGetDefaultView_RedirectToLoginPage()
        {
            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.Login("chernikov@gmail.com", "password2", false);

            var httpContext = new MockHttpContext(auth).Object;
            var controller = DependencyResolver.Current.GetService<Areas.Admin.Controllers.HomeController>();
            var route = new RouteData();
            route.Values.Add("controller", "Home");
            route.Values.Add("action", "Index");
            route.Values.Add("area", "Admin");

            ControllerContext context = new ControllerContext(new RequestContext(httpContext, route), controller);
            controller.ControllerContext = context;

            var controllerActionInvoker = new FakeControllerActionInvoker<HttpUnauthorizedResult>();
            var result = controllerActionInvoker.InvokeAction(controller.ControllerContext, "Index");
        }

        [Test]
        public void Index_AdminAuthorize_GetViewResult()
        {
            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.Login("admin", "password", false);

            var httpContext = new MockHttpContext(auth).Object;
            var controller = DependencyResolver.Current.GetService<Areas.Admin.Controllers.HomeController>();
            var route = new RouteData();
            route.Values.Add("controller", "Home");
            route.Values.Add("action", "Index");
            route.Values.Add("area", "Admin");

            ControllerContext context = new ControllerContext(new RequestContext(httpContext, route), controller);
            controller.ControllerContext = context;

            var controllerActionInvoker = new FakeControllerActionInvoker<ViewResult>();
            var result = controllerActionInvoker.InvokeAction(controller.ControllerContext, "Index");
        }
    }
}
