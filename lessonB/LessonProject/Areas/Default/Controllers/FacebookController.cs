using LessonProject.FacebookAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class FacebookController : DefaultController
    {
        private FbProvider fbProvider;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            fbProvider = new FbProvider();
            fbProvider.Config = Config.FacebookSetting;
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return Redirect(fbProvider.Authorize("http://" + HostName + "/Facebook/Token"));
        }

        public ActionResult Token()
        {
            if (Request.Params.AllKeys.Contains("code"))
            {
                var code = Request.Params["code"];
                if (fbProvider.GetAccessToken(code, "http://" + HostName + "/Facebook/Token"))
                {

                 /*   var jObj = fbProvider.GetUserInfo();
                    var fbUserInfo = JsonConvert.DeserializeObject<FbUserInfo>(jObj.ToString());
                    */
                    ViewBag.Token = fbProvider.AccessToken;
                    return View();
                }
                
            }
            return View("CantInitialize");
        }

    }
}
