using System.Web;
using System.Web.Optimization;

namespace CustomerManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryjs").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                   "~/Scripts/jquery.validate*"
                   ));

            //admin bundle
            bundles.Add(new ScriptBundle("~/Content/adminbootstrapcss").Include(
                      "~/Content/css/sb-admin-2.min.css",
                      "~/Content/css/Style.css"
                      ));

            //Font Awesome
            bundles.Add(new ScriptBundle("~/Content/fontawesome").Include(
                     "~/Content/vendor/fontawesome-free/css/all.css"
                     ));

            //Jquery And Bootstrap JS
            //bundles.Add(new ScriptBundle("~/bundles/jqueryjs").Include(
            //            "~/Content/vendor/jquery/jquery.min.js"
            //            ));

            //BootStrap JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"
                       ));

            //Jquery easing plugin
            bundles.Add(new ScriptBundle("~/bundles/jqueryeasing").Include(
                        "~/Content/vendor/jquery-easing/jquery.easing.min.js"
                        ));

            //Jquery easing plugin
            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                        "~/Content/js/sb-admin-2.js"
                        ));

            //Chart Plugin
            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                       "~/Content/vendor/chart.js/Chart.min.js"
                       ));

            //Chart and Pie Demo
            bundles.Add(new ScriptBundle("~/bundles/chardemo").Include(
                       "~/Content/js/demo/chart-area-demo.js",
                       "~/Content/js/demo/chart-pie-demo.js"
                       ));

            //DataTable Plugin
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                       "~/Content/vendor/datatables/jquery.dataTables.js",
                       "~/Content/vendor/datatables/dataTables.bootstrap4.min.js"
                       ));

            //DataTable Page Level Custom Scripts
            bundles.Add(new ScriptBundle("~/bundles/datatablescustom").Include(
                       "~/Content/js/demo/datatables-demo.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
