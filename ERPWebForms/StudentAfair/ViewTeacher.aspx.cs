using ERPWebForms;
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
    public partial class ViewTeacher : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewTeacher, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                DataTable dt = DataAccess.ExecuteSQLQuery("SELECT [ID], [Name] FROM [Std_Course]");
                cblCourses.DataSource = dt;
                cblCourses.DataTextField = "Name";
                cblCourses.DataValueField = "ID";
                cblCourses.DataBind();
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Teacher T = new Teacher();
                        T.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtTeacherName.Text = T.Name;

                        txtPhone.Text = T.Phone;
                        txtAddress.Text = T.Address;
                        txtEmail.Text = T.Email;

                        btnEdit.Visible = true;
                        ListItem li;
                        if (T.Courses != null && T.Courses.Rows != null && T.Courses.Rows.Count > 0)
                        {
                            for (int i = 0; i < T.Courses.Rows.Count; i++)
                            {
                                li = cblCourses.Items.FindByValue(T.Courses.Rows[i]["ID"].ToString());
                                if (li != null)
                                    li.Selected = true;
                            }
                        }



                    }
                }
                else
                {

                    btnEdit.Visible = false;
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddTeacher.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Teachers.aspx");
        }
    }
}