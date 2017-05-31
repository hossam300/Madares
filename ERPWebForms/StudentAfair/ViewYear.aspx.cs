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
    public partial class ViewYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        EducationalYear ed = new EducationalYear();
                        ed.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        lblEducationYearID.Text = ed.ID.ToString();
                        lblEducationYearName.Text = ed.Name;
                        lblRank.Text = ed.Rank.ToString();
                        lblLastModifiedDate.Text = ed.LastModifiedDate.ToString();
                        lblCreationDate.Text = ed.CreationDate.ToString();
                        txtBreakFrom.Text = ed.Breaks.Rows[0]["BreakFrom"].ToString();
                        txtBreakTo.Text = ed.Breaks.Rows[0]["BreakTo"].ToString();
                        txtLecTime.Text = ed.LecTimeMin.ToString();
                        txtNoOfLec.Text = ed.NoOfLec.ToString();
                        DataTable dt = ed.GetClasses(ed.ID);
                        ASPxGridView2.DataSource = dt;
                        ASPxGridView2.DataBind();
                        DataTable dt2 = ed.GetCourses(ed.ID);
                        ASPxGridView1.DataSource = dt2;
                        ASPxGridView1.DataBind();
                        btnEdit.Visible = true;
                    }
                    else
                    {

                        btnEdit.Visible = false;
                    }
                }
            }
            AddSubmitEvent();
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportClassw.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportClassx.UniqueID;
            UpdatePanelControlTrigger trigger3 = new PostBackTrigger();
            trigger3.ControlID = btnExportCoursesw.UniqueID;
            UpdatePanelControlTrigger trigger4 = new PostBackTrigger();
            trigger4.ControlID = btnExportCoursesx.UniqueID;
            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);
            updatePanel.Triggers.Add(trigger3);
            updatePanel.Triggers.Add(trigger4);

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddYear.aspx?id=" + Request.QueryString["id"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/EducationYears.aspx");
        }
        protected void ASPxGridView2_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
        protected void ASPxGridView2_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
        protected void btnNewClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddClass.aspx?id=" + Request.QueryString["id"].ToString());
        }
        protected void btnExportClassx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportClassw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void btnNewCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddCourse.aspx?id=" + Request.QueryString["id"].ToString());

        }
        protected void btnExportCoursesx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter2.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportCoursesw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter2.WriteRtfToResponse();

        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
    }
}