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
    public partial class AddTeacher : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddTeacher, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            /*<asp:SqlDataSource runat="server" ID="DataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_Course]"></asp:SqlDataSource>
            DataSourceID ="DataSource1" DataTextField="Name" DataValueField="ID"*/

            if (!IsPostBack)
            {
                DataTable dt = DataAccess.ExecuteSQLQuery("SELECT [ID], [Name] FROM [Std_Course]");
                cblCourses.DataSource = dt;
                cblCourses.DataTextField = "Name";
                cblCourses.DataValueField = "ID";
                cblCourses.DataBind();
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }

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
                        btnSave.Visible = false;
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
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Name = txtTeacherName.Text;
            t.Email = txtEmail.Text;
            t.Address = txtAddress.Text;
            t.Phone = txtPhone.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            t.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            DataTable d = new DataTable();
            d.Columns.Add("CourseID");
            DataRow dr;
            for (int i = 0; i < cblCourses.Items.Count; i++)
            {
                if (cblCourses.Items[i].Selected)
                {
                    dr = d.NewRow();
                    dr["CourseID"] = cblCourses.Items[i].Value.ToString();
                    d.Rows.Add(dr);
                }
            }
            t.Courses = d;
            int id = t.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Teachers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddTeacher.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Teachers.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Name = txtTeacherName.Text;
            t.Email = txtEmail.Text;
            t.Address = txtAddress.Text;
            t.Phone = txtPhone.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            t.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            t.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable d = new DataTable();
            d.Columns.Add("CourseID");
            DataRow dr;
            for (int i = 0; i < cblCourses.Items.Count; i++)
            {
                if (cblCourses.Items[i].Selected)
                {
                    dr = d.NewRow();
                    dr["CourseID"] = cblCourses.Items[i].Value.ToString();
                    d.Rows.Add(dr);
                }
            }
            t.Courses = d;
            int id = t.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Teachers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddTeacher.aspx?id=0&&alret=notpass");
            }

        }
    }
}