using System.Web.Optimization;
using System.Web.UI;

namespace AppWebReportes
{
    public class BundleConfig
    {
        // Para obtener más información sobre la unión, visite http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // El orden es muy importante para el funcionamiento de estos archivos ya que tienen dependencias explícitas
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
            // para la producción, use la herramienta de creación en http://modernizr.com para elegir solo las pruebas que necesite
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            // datatables
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                            "~/Scripts/jquery-3.0.0.min.js",
                            "~/Scripts/tether.min.js",
                            "~/Scripts/bootstrap.min.js",
                            "~/Scripts/DataTables/jquery.dataTables.min.js",
                            "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                            "~/Scripts/DataTables/dataTables.responsive.min.js",
                            "~/Scripts/DataTables/responsive.bootstrap4.min.js",
                            "~/Scripts/DataTables/autoFill.bootstrap4.min.js",
                            "~/Scripts/DataTables/buttons.bootstrap4.min.js"));
            // Validaciones
            bundles.Add(new ScriptBundle("~/bundles/validaciones").Include(
                            "~/Scripts/jquery.validate.min.js",
                            "~/Scripts/additional-methods.min.js",
                            "~/Scripts/DatePicker/datepicker.min.js",
                            "~/Scripts/DatePicker/datepicker.es-ES.js"
                            ));
            //Export data
            bundles.Add(new ScriptBundle("~/bundles/export").Include(
                            "~/Scripts/DataTables/export/dataTables.buttons.min.js",
                            "~/Scripts/DataTables/export/buttons.flash.min.js",
                            "~/Scripts/DataTables/export/jszip.min.js",
                            "~/Scripts/DataTables/export/pdfmake.min.js",
                            "~/Scripts/DataTables/export/vfs_fonts.js",
                            "~/Scripts/DataTables/export/buttons.html5.min.js",
                            "~/Scripts/DataTables/export/buttons.print.min.js",
                            "~/Scripts/DataTables/export/idioma.js",
                            "~/Scripts/DataTables/export/numeral.min.js",
                            "~/Scripts/Charts/highcharts.min.js",
                            "~/Scripts/Charts/jquery.highchartTable-min.js",
                            "~/Scripts/Charts/series-label.js",
                            "~/Scripts/Charts/exporting.js",
                            "~/Scripts/Charts/highcharts-3d.min.js"
                            ));


            // Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
            // para la producción, use la herramienta de creación en http://modernizr.com para elegir solo las pruebas que necesite
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}