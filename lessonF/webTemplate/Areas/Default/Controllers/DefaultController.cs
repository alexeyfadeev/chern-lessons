using System.Linq;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using System.Resources;

using webTemplate.Controllers;
using webTemplate.Global;
using webTemplate.Helpers;
using webTemplate.App_LocalResources;
using webTemplate.Model;

namespace webTemplate.Areas.Default.Controllers
{
    public abstract class DefaultController : BaseController
    {
        protected int CurrentLangID { get; set; }

        protected string CurrentLangCode { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            var ci = Config.Culture;
            CurrentLangCode = Config.CultureCode;
            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                try
                {
                    CurrentLangCode = requestContext.RouteData.Values["lang"] as string;
                    if (CurrentLangCode != null)
                    {
                        ci = new CultureInfo(CurrentLangCode);
                    }
                }
                catch
                {
                    requestContext.HttpContext.Response.Redirect(NotFoundPage);
                }
            }
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);

            var currentLang =
                Repository.Languages.FirstOrDefault(p => string.Compare(p.Code, CurrentLangCode, true) == 0);
            if (currentLang != null)
            {
                CurrentLangID = currentLang.ID;
            }
            else
            {
                CurrentLangID = 0;
            }
            base.Initialize(requestContext);
        }
    }
}
