using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateEmployee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateEmployee, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
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
                        Employee emp = new Employee();
                        emp.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        string empname = emp.EmpName;
                        string[] ssize = empname.Split(' ', '\t');

                        txtfname.Text = ssize[0];
                        txtmname.Text = ssize[1];
                        txtlname.Text = ssize[2];
                        txtEmpCode.Text = emp.EmpCode;
                        txtSallary.Text = emp.Sallary.ToString();
                        txtSpecialty.Text = emp.Specialty;
                        if (emp.ReportTo.ToString() == "0")
                        {

                        }
                        else
                        {
                            ddlReportTo.SelectedValue = emp.ReportTo.ToString();
                        }

                        ddlNationality.SelectedValue = (emp.Nationality.ToString());
                        ddlJobCategory.SelectedValue = emp.JobCategoryID.ToString();
                        ddlJobTitle.SelectedValue = emp.JobTitleID.ToString();
                        ddlPayGrade.SelectedValue = emp.PayGradeID.ToString();
                        txthirngdate.Text = emp.HiringDate.ToShortDateString();

                        ddlReligion.SelectedValue = emp.Religion.ToString() ;
                        ddlQualification.SelectedValue = emp.Qualification.ToString();
                        ddlMaritalStatus.SelectedValue = emp.MaritalStatus.ToString();
                        txtIDNumber.Text = emp.IDNumber;
                        txtAddress.Text = emp.Address;
                        txtTelephoneNo.Text = emp.TeleNumber.ToString();
                        txtGraduationYear.Text = emp.GraduationYear.ToString();
                        txtExperience.Text = emp.Experience;
                        if (emp.ResignDate != DateTime.MinValue)
                            txtResignDate.Text = emp.ResignDate.ToShortDateString();
                        else
                            txtResignDate.Text = "";

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
            Employee emp = new Employee();
            emp.EmpName = txtfname.Text + " " + txtmname.Text + " " + txtlname.Text;
            if (txtSallary.Text == "")
            {
                emp.Sallary = 0;
            }
            else
            {
                emp.Sallary = Convert.ToDecimal(txtSallary.Text);
            }


            emp.Specialty = txtSpecialty.Text;
            if (ddlReportTo.SelectedValue.ToString() == "Choose User")
            {
                emp.ReportTo = 0;
            }
            else
            {
                emp.ReportTo = Convert.ToInt32(ddlReportTo.SelectedValue.ToString());
            }

            emp.Nationality = ddlNationality.SelectedValue.ToString();
            emp.EmpCode = txtEmpCode.Text;
            emp.PayGradeID = Convert.ToInt32(ddlPayGrade.SelectedValue.ToString());
            emp.JobTitleID = Convert.ToInt32(ddlJobTitle.SelectedValue.ToString());
            emp.JobCategoryID = Convert.ToInt32(ddlJobCategory.SelectedValue.ToString());
            
            emp.Religion = Convert.ToInt32(ddlReligion.SelectedValue.ToString());
            emp.Qualification = Convert.ToInt32(ddlQualification.SelectedValue.ToString());
            emp.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue.ToString());
            emp.IDNumber = txtIDNumber.Text;
            emp.Address = txtAddress.Text;
            emp.TeleNumber = int.Parse(txtTelephoneNo.Text);
            emp.GraduationYear = int.Parse(txtGraduationYear.Text);
            emp.Experience = txtExperience.Text;
            if (!string.IsNullOrEmpty( txtResignDate.Text) )
                emp.ResignDate = DateTime.Parse(txtResignDate.Text);
                

            emp.HiringDate = DateTime.Parse(txthirngdate.Text); 
            HttpCookie myCookie = Request.Cookies["user"];
            emp.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = emp.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/Employees.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateEmployee.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Employees.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            emp.EmpName = txtfname.Text + " " + txtmname.Text + " " + txtlname.Text;
            if (txtSallary.Text == "")
            {
                emp.Sallary = 0;
            }
            else
            {
                emp.Sallary = Convert.ToDecimal(txtSallary.Text);
            }


            emp.Specialty = txtSpecialty.Text;
            if (ddlReportTo.SelectedValue.ToString() == "Choose User")
            {
                emp.ReportTo = 0;
            }
            else
            {
                emp.ReportTo = Convert.ToInt32(ddlReportTo.SelectedValue.ToString());
            }

            emp.Nationality = ddlNationality.SelectedValue.ToString();
            emp.EmpCode = txtEmpCode.Text;
            emp.PayGradeID = Convert.ToInt32(ddlPayGrade.SelectedValue.ToString());
            emp.JobTitleID = Convert.ToInt32(ddlJobTitle.SelectedValue.ToString());
            emp.JobCategoryID = Convert.ToInt32(ddlJobCategory.SelectedValue.ToString());
            emp.HiringDate = DateTime.Parse(txthirngdate.Text); 

            emp.Religion = Convert.ToInt32(ddlReligion.SelectedValue.ToString());
            emp.Qualification = Convert.ToInt32(ddlQualification.SelectedValue.ToString());
            emp.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue.ToString());
            emp.IDNumber = txtIDNumber.Text;
            emp.Address = txtAddress.Text;
            emp.TeleNumber = int.Parse(txtTelephoneNo.Text);
            emp.GraduationYear = int.Parse(txtGraduationYear.Text);
            emp.Experience = txtExperience.Text;
            if (!string.IsNullOrEmpty(txtResignDate.Text))
                emp.ResignDate = DateTime.Parse(txtResignDate.Text);

            HttpCookie myCookie = Request.Cookies["user"];
            emp.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = emp.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/Employees.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateEmployee.aspx?id=0&&alret=notpass");
            }
        }
    }
}