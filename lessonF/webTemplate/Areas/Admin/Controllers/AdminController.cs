using System.Linq;
using webTemplate.Controllers;
using webTemplate.Model;
using System.Web.Routing;
using System.Globalization;
using System.Threading;

namespace webTemplate.Areas.Admin.Controllers
{

    public abstract class AdminController : BaseController
    {
        protected Language CurrentLang
        {
            get
            {
                return (CurrentUser != null ? CurrentUser.Language : null) ?? Repository.Languages.First();
            }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            CultureInfo ci = new CultureInfo("ru");

            Thread.CurrentThread.CurrentCulture = ci;
            base.Initialize(requestContext);
        }

    }
}
