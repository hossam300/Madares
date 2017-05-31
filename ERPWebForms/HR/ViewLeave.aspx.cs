using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewLeave : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewLeave , Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Leave leaves = new Leave();
                        leaves.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        Employee emp = new Employee();
                        emp.get(leaves.EmpID);
                        ddlEmp.Text = emp.EmpName;
                        LeaveType type = new LeaveType();
                        type.get(leaves.LeaveTypeID);
                        ddlLeaveType.Text = type.LeaveTypeName;
                        txtfrom.Text = leaves.FromDate.ToShortDateString();
                        txtTo.Text = leaves.ToDate.ToShortDateString();
                        txtComment.Text = leaves.Comment;


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
            Response.Redirect("~/HR/AddLeaves.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Leaves.aspx");
        }
    }
}