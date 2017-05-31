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
    public partial class ViewCourse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewCourse, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Course cr = new Course();
                        cr.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtCourseName.Text = cr.Name;
                        txtDescription.Text = cr.Description;
                        txtMin.Text = cr.Min.ToString();
                        txtMax.Text = cr.Max.ToString();
                        DataTable dtEdy = cr.Edy;
                        DataTable dtTeachers = cr.Teachers;
                        // Fill the Checkboxlists by dtEdy
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (cblKg.Items[i].Value.ToString() == dt.Rows[i]["ID"].ToString())
                        //    {
                        //        cblKg.Items[i].Selected = true;
                        //    }
                        //    if (cblPri.Items[i].Value.ToString() == dt.Rows[i]["ID"].ToString())
                        //    {
                        //        cblPri.Items[i].Selected = true;
                        //    }
                        //    if (cblPre.Items[i].Value.ToString() == dt.Rows[i]["ID"].ToString())
                        //    {
                        //        cblPre.Items[i].Selected = true;
                        //    }
                        //}
                        ASPxGridView1.DataSource = dtTeachers;
                        ASPxGridView1.DataBind();
                        btnEdit.Visible = true;
                    }
                    else
                    {

                        btnEdit.Visible = false;
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddCourse.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Courses.aspx");
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/StudentAfair/AddTeacher.aspx?id=" + id);
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/StudentAfair/ViewTeacher.aspx?id=" + id);
            }
        }
        protected void ASPxGridView2_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/StudentAfair/ViewDocuments.aspx?id=" + id);
            }

        }
        protected void ASPxGridView2_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/StudentAfair/AddDocuments.aspx?id=" + id);
        }
        protected void btnNewDocuments_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddDocuments.aspx?id=0&&CourseID=" + id);
        }
    }
}