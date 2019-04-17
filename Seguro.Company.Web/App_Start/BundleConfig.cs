using System.Web;
using System.Web.Optimization;

namespace Seguro.Company.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                        "~/Scripts/holder.js",
                        "~/Scripts/ie10-viewport-bug-workaround.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                      "~/Scripts/lightslider.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/ie-emulation-modes-warning.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/responsive.css",
                      "~/Content/font-awesome.css",
                      "~/Content/lightslider.css",
                      "~/Content/yamm.css",
                      "~/Content/demo.css"));
        }
    }
}
