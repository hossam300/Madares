using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddStudent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddStudent, Request.Cookies["user"]["Permission"].ToString()))
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
                        Student student = new Student();
                        student.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtStudentName.Text = student.Name;
                        Parent parent = new Parent();
                        parent.get(student.ParentID);
                        ddlParentName.Value = student.ParentID.ToString();
                        txtParentJob.Text = parent.Job;
                        txtBirthDate.Text = student.BirthDate.ToShortDateString();
                        DateTime ioct = new DateTime(DateTime.Now.Year, 10, 1);
                        txtPhone.Text = parent.Phone;
                        ddlType.Value = student.Type.ToString();
                        txtAddress.Text = student.Address.ToString();
                        ddlClass.Value = student.StudClass.ToString();
                        rblGender.SelectedValue = student.Gender;
                        rblReligion.SelectedValue = student.Religion;
                        txtUserName.Text = student.UserName;
                        txtUserName.Enabled = false;
                        if (student.LearningDisabilities == 1)
                        {
                            cbtxtDisabilities.Checked = true;
                        }
                        else
                            cbtxtDisabilities.Checked = false;
                        txtDisabilities.Text = student.Note;
                        if (student.Father != 0)
                        {
                            ddlFather.Value = student.Father;
                            parent.get(student.Father);
                            txtfjob.Text = parent.Job;
                            txtfPhone.Text = parent.Phone;
                            txtfAddress.Text = parent.Address;
                        }
                        if (student.Mother != 0)
                        {
                            ddlMpther.Value = student.Mother;
                            parent.get(student.Mother);
                            txtmJob.Text = parent.Job;
                            txtmphone.Text = parent.Phone;
                            txtmAddress.Text = parent.Address;
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
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Name = txtStudentName.Text;
            std.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            int pID = 0;
            int.TryParse(ddlParentName.Value.ToString(), out pID); // need to be changed to combo box
            std.ParentID = pID;
            std.Address = txtAddress.Text;
            std.Phone = txtPhone.Text;
            DateTime brt = DateTime.MinValue;
            DateTime.TryParse(txtBirthDate.Text, out brt);
            std.BirthDate = brt;
            int type = 0;
            int.TryParse(ddlType.Value.ToString(), out type);
            std.Type = type;
            int stClass = 0;
            int.TryParse(ddlClass.Value.ToString(), out stClass);
            std.StudClass = stClass;
            HttpCookie myCookie = Request.Cookies["user"];
            std.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            std.Gender = rblGender.SelectedValue;
            std.Religion = rblReligion.SelectedValue;
            if (cbtxtDisabilities.Checked)
            {
                std.LearningDisabilities = 1;
            }
            else
            {
                std.LearningDisabilities = 0;
            }
            std.Note = txtDisabilities.Text;
            if (ddlFather.Value != null)
            {
                std.Father = Convert.ToInt32(ddlFather.Value);
            }
            else
            {
                std.Father = 0;
            }

            if (ddlMpther.Value != null)
            {
                std.Mother = Convert.ToInt32(ddlFather.Value);
            }
            else
            {
                std.Mother = 0;
            }
            std.UserName = txtUserName.Text;
            int id = std.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Students.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddStudent.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Name = txtStudentName.Text;
            int pID = 0;
            int.TryParse(ddlParentName.Value.ToString(), out pID); // need to be changed to combo box
            std.ParentID = pID;
            std.Address = txtAddress.Text;
            std.Phone = txtPhone.Text;
            DateTime brt = DateTime.MinValue;
            DateTime.TryParse(txtBirthDate.Text, out brt);
            std.BirthDate = DateTime.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            // std.BirthDate = brt;
            int type = 0;
            int.TryParse(ddlType.Value.ToString(), out type);
            std.Type = type;
            int stClass = 0;
            int.TryParse(ddlClass.Value.ToString(), out stClass);
            std.StudClass = stClass;
            HttpCookie myCookie = Request.Cookies["user"];
            std.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            std.Gender = rblGender.SelectedValue;
            std.Religion = rblReligion.SelectedValue;
            if (cbtxtDisabilities.Checked)
            {
                std.LearningDisabilities = 1;
            }
            else
            {
                std.LearningDisabilities = 0;
            }
            std.Note = txtDisabilities.Text;
            if ( ddlFather.Value == null )
            {
                std.Father = 0;
            }
            else
            {
                std.Father = Convert.ToInt32(ddlFather.Value.ToString());
            }
            if ( ddlMpther.Value == null )
            {
                std.Mother = 0;
            }
            else
            {
                std.Mother = Convert.ToInt32(ddlMpther.Value.ToString());
            }

            std.UserName = txtUserName.Text;
          
            int id =0;
            try
            {
                id= std.save();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/StudentAfair/Students.aspx?ex=" + ex);
            }
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Students.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddStudent.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Students.aspx");
        }
        protected void ddlParentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.get(int.Parse(ddlParentName.Value.ToString()));
            txtParentJob.Text = p.Job;
            txtAddress.Text = p.Address;
            txtPhone.Text = p.Phone;
        }

        protected void ddlFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.get(int.Parse(ddlParentName.Value.ToString()));
            txtfjob.Text = p.Job;
            txtfPhone.Text = p.Phone;
            txtfAddress.Text = p.Address;
        }

        protected void ddlMpther_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.get(int.Parse(ddlParentName.Value.ToString()));
            txtmJob.Text = p.Job;
            txtmphone.Text = p.Phone;
            txtmAddress.Text = p.Address;
        }
    }
}