using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AllTransactions : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AllTransactions, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            AddSubmitEvent();
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('تم الحفظ بنجاح.');</script>");
                }
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AccountingUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportToXlsx.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportToRtf.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);
        }

        protected void btnExportToRtf_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });

        }
    }
}