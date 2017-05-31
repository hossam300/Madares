
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
    public partial class ViewExam : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewExam, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Exam exam = new Exam();
                        exam.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtExamName.Text = exam.Name;
                        txtDescription.Text = exam.Description;
                        txtExamDate.Text = exam.ExamDate.ToShortDateString();
                        ddlNature.SelectedValue = exam.Nature.ToString();
                        ddlType.SelectedValue = exam.Type.ToString();
                        ddlEdYear.SelectedValue = exam.EdyID.ToString();
                        getEdyClassCourse(exam.EdyID);
                        ListItem li;
                        if (exam.Courses != null && exam.Courses.Rows != null && exam.Courses.Rows.Count > 0)
                        {
                            for (int i = 0; i < exam.Courses.Rows.Count; i++)
                            {
                                li = cblCourses.Items.FindByValue(exam.Courses.Rows[i]["ID"].ToString());
                                if (li != null)
                                    li.Selected = true;
                            }
                        }

                        if (exam.Classes != null && exam.Classes.Rows != null && exam.Classes.Rows.Count > 0)
                        {
                            for (int i = 0; i < exam.Classes.Rows.Count; i++)
                            {
                                li = cblClasses.Items.FindByValue(exam.Classes.Rows[i]["ID"].ToString());
                                if (li != null)
                                    li.Selected = true;
                            }
                        }
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
            Response.Redirect("~/StudentAfair/AddExam.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Exams.aspx");
        }
        private void getEdyClassCourse(int EdyID)
        {
            //get the courses for this educational year
            string sql = "select Name,ID from Std_Course inner join Std_CourseEdy on CourseID = ID where EdyID = " + EdyID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            cblCourses.DataSource = dt;
            cblCourses.DataTextField = "Name";
            cblCourses.DataValueField = "ID";
            cblCourses.DataBind();
            //get the classes for this educational year
            sql = "select Name,ID from Std_Class where EdyID = " + EdyID.ToString();
            dt = DataAccess.ExecuteSQLQuery(sql);
            cblClasses.DataSource = dt;
            cblClasses.DataTextField = "Name";
            cblClasses.DataValueField = "ID";
            cblClasses.DataBind();
        }
    }
}