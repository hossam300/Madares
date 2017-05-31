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
    public partial class Exams : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Exams, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            DataTable dt = new Exam().getList();

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
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportExamw.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportExamx.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void btnExportExamw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void btnExportExamx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnNewExam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddExam.aspx?id=0");
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/StudentAfair/AddExam.aspx?id=" + id);
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
            DataRow dr = ASPxGridView1.GetDataRow(Gid);
            int id = Convert.ToInt32(dr["id"].ToString());
            if (e.ButtonID == "btnview")
            {

                Response.Redirect("~/StudentAfair/ViewExam.aspx?id=" + id);
            }
            else if (e.ButtonID == "btnDegrees")
            {
                Response.Redirect("~/StudentAfair/AddExamDegree.aspx?id=" + id);
            }
        }
    }
}