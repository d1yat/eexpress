using System.Web;
using System.Web.Optimization;

namespace EExpress
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-lte").Include(
                      "~/admin-lte/js/adminlte.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.extensions.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.date.extensions.js",
                        //and other extensions you want to include
                        "~/Scripts/jquery.inputmask/jquery.inputmask.numeric.extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                      "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/admin-lte").Include(
                      "~/admin-lte/css/AdminLTE.css"));

            bundles.Add(new StyleBundle("~/Content/skin-red").Include(
                      "~/admin-lte/css/skins/skin-red.css"));

            bundles.Add(new StyleBundle("~/Content/skin-green").Include(
                      "~/admin-lte/css/skins/skin-green.css"));

            bundles.Add(new StyleBundle("~/Content/skin-blue").Include(
                      "~/admin-lte/css/skins/skin-blue.css"));

        }
    }
}
