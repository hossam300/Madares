using DevExpress.Export;
using DevExpress.XtraPrinting;
using ERPWebForms.Business.control.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class SittingNumberList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Classes, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            AddSubmitEvent();

        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportDriverw.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportDriverx.UniqueID;
            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void btnExportDriverx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void btnExportDriverw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            new ClsSittingNumber().InsertBulk();
        }
    }
}