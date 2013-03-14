using System.Web.Mvc;

namespace webTemplate.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "error",
                "error",
                new { controller = "Error", action = "Index" },
                new[] { "webTemplate.Areas.Default.Controllers" }
            );

            context.MapRoute(
                "notFoundPage",
                "not-found-page",
                new { controller = "Error", action = "NotFoundPage" },
                new[] { "webTemplate.Areas.Default.Controllers" }
            );
            context.MapRoute(
                null,
                "{lang}/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", lang = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "webTemplate.Areas.Default.Controllers" }
            );
        }
    }
}
