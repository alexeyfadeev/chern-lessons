using System.Web;
using System.Web.Optimization;

namespace webTemplate
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-1.*"));
            bundles.Add(new ScriptBundle("~/bundles/fineuploader").Include(
                      "~/Scripts/jquery.fineuploader*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/reset.css", "~/Content/css/main.css"));
            bundles.Add(new StyleBundle("~/Content/css/admin").Include("~/Content/css/admin.css"));
            bundles.Add(new StyleBundle("~/Content/css/fineuploader").Include("~/Content/css/fineuploader.css"));

            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include("~/Content/css/bootstrap.css", "~/Content/css/bootstrap-responsive.css"));

        }
    }
}