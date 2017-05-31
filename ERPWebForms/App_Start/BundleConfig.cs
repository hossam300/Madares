using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace ERPWebForms
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
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

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle ("~/bundles/js").Include(
                "~/js/jquery-1.7.1.min.js",
                "~/js/jquery-ui-1.8.18.custom.min.js",
                "~/js/jquery.ui.touch-punch.js",
                "~/js/chosen.jquery.js",
                "~/js/uniform.jquery.js",
                "~/js/bootstrap-dropdown.js",
                "~/js/bootstrap-colorpicker.js",
                "~/js/sticky.full.js",
                "~/js/jquery.noty.js",
                "~/js/selectToUISlider.jQuery.js",
                "~/js/fg.menu.js",
                "~/js/jquery.tagsinput.js",
                "~/js/jquery.cleditor.js",
                "~/js/jquery.tipsy.js",
                "~/js/jquery.peity.js",
                "~/js/jquery.simplemodal.js",
                "~/js/jquery.jBreadCrumb.1.1.js",
                "~/js/jquery.colorbox-min.js",
                "~/js/jquery.idTabs.min.js",
                "~/js/jquery.multiFieldExtender.min.js",
                "~/js/jquery.confirm.js",
                "~/js/elfinder.min.js",
                "~/js/accordion.jquery.js",
                "~/js/autogrow.jquery.js",
                "~/js/check-all.jquery.js",
                "~/js/data-table.jquery.js",
                "~/js/ZeroClipboard.js",
                "~/js/TableTools.min.js",
                "~/js/jeditable.jquery.js",
                "~/js/duallist.jquery.js",
                "~/js/easing.jquery.js",
                "~/js/full-calendar.jquery.js",
                "~/js/input-limiter.jquery.js",
                "~/js/inputmask.jquery.js",
                "~/js/iphone-style-checkbox.jquery.js",
                "~/js/meta-data.jquery.js",
                "~/js/quicksand.jquery.js",
                "~/js/raty.jquery.js",
                "~/js/smart-wizard.jquery.js",
                "~/js/stepy.jquery.js",
                "~/js/treeview.jquery.js",
                "~/js/ui-accordion.jquery.js",
                "~/js/vaidation.jquery.js",
                "~/js/mosaic.1.0.1.min.js",
                "~/js/jquery.collapse.js",
                "~/js/jquery.cookie.js",
                "~/js/jquery.autocomplete.min.js",
                "~/js/localdata.js",
                "~/js/excanvas.min.js",
                "~/js/jquery.jqplot.min.js",
                "~/js/chart-plugins/jqplot.dateAxisRenderer.min.js",
                "~/js/chart-plugins/jqplot.cursor.min.js",
                "~/js/chart-plugins/jqplot.logAxisRenderer.min.js",
                "~/js/chart-plugins/jqplot.canvasTextRenderer.min.js",
                "~/js/chart-plugins/jqplot.highlighter.min.js",
                "~/js/chart-plugins/jqplot.pieRenderer.min.js",
                "~/js/chart-plugins/jqplot.barRenderer.min.js",
                "~/js/chart-plugins/jqplot.categoryAxisRenderer.min.js",
                "~/js/chart-plugins/jqplot.pointLabels.min.js",
                "~/js/custom-scripts.js"
                ));
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