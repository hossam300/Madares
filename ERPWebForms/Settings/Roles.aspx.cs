using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class Roles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Roles, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Settings/UnAuthorized.aspx");
            }
            UserSecurity Us= new UserSecurity();
            DataTable dt = Us.getRolesList();
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
            UpdatePanel updatePanel = Page.Master.FindControl("SettingUpdatePanel") as UpdatePanel;
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
            Response.Redirect("~/Settings/AddRole.aspx?id=0");
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Settings/ViewRole.aspx?ID=" + id);
            }
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/Settings/AddRole.aspx?ID=" + id);
        }
    }
}