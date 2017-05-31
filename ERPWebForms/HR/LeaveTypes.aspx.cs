using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class LeaveTypes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.LeaveTypes, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            LeaveType leaveType = new LeaveType();
            DataTable dt = new DataTable();
            dt = leaveType.getList();

            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
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
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = ASPxButton1.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = ASPxButton2.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/AddLeaveType.aspx?id=0");
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/HR/AddLeaveType.aspx?id=" + id);
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["LeaveTypeID"].ToString());
                Response.Redirect("~/HR/ViewLeaveType.aspx?id=" + id);


            }
        }
    }
}