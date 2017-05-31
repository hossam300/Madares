using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewEmployee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewEmployee, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Employee emp = new Employee();
                        emp.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        string empname = emp.EmpName;
                        string[] ssize = empname.Split(' ', '\t');
                        txtEmpID.Text = emp.ID.ToString();
                        txtfname.Text = ssize[0];
                        txtmname.Text = ssize[1];
                        txtlname.Text = ssize[2];
                        txtEmpCode.Text = emp.EmpCode;
                        txtSallary.Text = emp.Sallary.ToString();
                        txtSpecialty.Text = emp.Specialty;
                        if (emp.ReportTo.ToString() == "0")
                        {
                            ddlReportTo.Text = "None";
                        }
                        else
                        {
                            Employee ReportTo = new Employee();
                            ReportTo.get(Convert.ToInt32(emp.ReportTo.ToString()));
                            ddlReportTo.Text = ReportTo.EmpName;
                        }

                        ddlNationality.Text = emp.Nationality;
                        txthirngdate.Text = emp.HiringDate.ToShortDateString();

                    }

                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/CreateEmployee.aspx?id=" + Request.QueryString["id"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Employees.aspx");
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["BonceID"].ToString());
                Response.Redirect("~/HR/ViewBonus.aspx?id=" + id);
            }
        }

        protected void ASPxGridView2_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview3")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView2.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["BonceID"].ToString());
                Response.Redirect("~/HR/ViewDeduction.aspx?id=" + id);
            }
        }

        protected void ASPxGridView3_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview2")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView3.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["LeaveID"].ToString());
                Response.Redirect("~/HR/ViewLeave.aspx?id=" + id);
            }
            
        }

        protected void ASPxGridView4_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview1")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView4.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["ReviewID"].ToString());
                Response.Redirect("~/HR/ViewReview.aspx?id=" + id);
            }
        }
    }
}