using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Global.Auth;
using LessonProject.Mappers;
using LessonProject.Model;
using Ninject;
using LessonProject.Global.Config;
using System.Globalization;
using System.Threading;

namespace LessonProject.Controllers
{
    public abstract class BaseController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        [Inject]
        public IConfig Config { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        protected static string ErrorPage = "~/Error";

        protected static string NotFoundPage = "~/NotFoundPage";

        protected static string LoginPage = "~/Login";

        public RedirectResult RedirectToNotFoundPage
        {
            get
            {
                return Redirect(NotFoundPage);
            }
        }

        public RedirectResult RedirectToLoginPage
        {
            get
            {
                return Redirect(LoginPage);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            try
            {
                var cultureInfo = new CultureInfo(Config.Lang);

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
            catch (Exception ex)
            {
                logger.Error("Culture not found", ex);
            }

            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Result = Redirect(ErrorPage);
        }
    }
}
