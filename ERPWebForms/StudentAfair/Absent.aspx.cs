using DevExpress.Export;
using DevExpress.XtraPrinting;
//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ERPWebForms.StudentAfair
{
    public partial class Absent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Absent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            AddSubmitEvent();
            DataTable dt = new Student().getAbsent();

            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportAbsenttw.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportAbsenttx.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void btnNewAbsent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddAbsent.aspx?id=0");
        }
        protected void btnExportAbsenttx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportAbsenttw_Click(object sender, EventArgs e)
        {

            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/StudentAfair/AddAbsent.aspx?id=" + id);
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnDelete")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "DELETE FROM [Std_Absent] WHERE ID=" + id;
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}