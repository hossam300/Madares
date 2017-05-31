using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebForms;
namespace ERPWebForms.StudentAfair
{
    public partial class AddExam : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddExam, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Exam exam = new Exam();
                        exam.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtExamName.Text = exam.Name;
                        txtDescription.Text = exam.Description;
                        txtExamDate.Text = exam.ExamDate.ToShortDateString();
                        ddlNature.Text = exam.Nature.ToString();
                        ddlType.Text = exam.Type.ToString();
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
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Exam sc = new Exam();
            sc.Name = txtExamName.Text;
            int type = 0;
            int.TryParse(ddlType.SelectedValue.ToString(), out type);
            sc.Type = type;
            int nat = 0;
            int.TryParse(ddlNature.SelectedValue.ToString(), out nat);
            sc.Nature = nat;
            sc.Description = txtDescription.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            sc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            //DateTime dt = DateTime.MinValue;
            //DateTime.TryParse(txtExamDate.Text, out dt);
            sc.ExamDate = Convert.ToDateTime(txtExamDate.Text);
            sc.EdyID =Convert.ToInt32(ddlEdYear.SelectedValue.ToString());
            DataRow dr;
            for (int i = 0; i < cblClasses.Items.Count; i++)
            {
                if (cblClasses.Items[i].Selected)
                {
                    dr = sc.Classes.NewRow();
                    dr["ID"] = cblClasses.Items[i].Value.ToString();
                    dr["Name"] = cblClasses.Items[i].Text.ToString();
                    sc.Classes.Rows.Add(dr);
                }
            }
            for (int i = 0; i < cblCourses.Items.Count; i++)
            {
                if (cblCourses.Items[i].Selected)
                {
                    dr = sc.Courses.NewRow();
                    dr["ID"] = cblCourses.Items[i].Value.ToString();
                    dr["Name"] = cblCourses.Items[i].Text.ToString();
                    sc.Courses.Rows.Add(dr);
                }
            }
            int id = sc.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Exams.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddExam.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Exams.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Exam sc = new Exam();
            sc.Name = txtExamName.Text;
            sc.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            int type = 0;
            int.TryParse(ddlType.SelectedValue.ToString(), out type);
            sc.Type = type;
            HttpCookie myCookie = Request.Cookies["user"];
            sc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int nat = 0;
            int.TryParse(ddlNature.SelectedValue.ToString(), out nat);
            sc.Nature = nat;
            sc.Description = txtDescription.Text;
            int edyID = 0;
            int.TryParse(ddlEdYear.SelectedValue.ToString(), out edyID);
            sc.EdyID = edyID;
            DateTime dt = DateTime.MinValue;
            DateTime.TryParse(txtExamDate.Text, out dt);
            sc.ExamDate = dt;
            DataRow dr;
            for (int i = 0; i < cblClasses.Items.Count; i++)
            {
                if (cblClasses.Items[i].Selected)
                {
                    dr = sc.Classes.NewRow();
                    dr["ID"] = cblClasses.Items[i].Value.ToString();
                    dr["Name"] = cblClasses.Items[i].Text.ToString();
                    sc.Classes.Rows.Add(dr);
                }
            }
            for (int i = 0; i < cblCourses.Items.Count; i++)
            {
                if (cblCourses.Items[i].Selected)
                {
                    dr = sc.Courses.NewRow();
                    dr["ID"] = cblCourses.Items[i].Value.ToString();
                    dr["Name"] = cblCourses.Items[i].Text.ToString();
                    
                    sc.Courses.Rows.Add(dr);
                }
            }
            int id = sc.update();
            Response.Redirect("~/StudentAfair/viewExam.aspx?id=" + id.ToString());
        }
        protected void ddlEdYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            getEdyClassCourse(int.Parse(ddlEdYear.SelectedValue.ToString()));

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