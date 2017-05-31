using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class AddLeaveType : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddLeaveType, Request.Cookies["user"]["Permission"].ToString()))
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
                        LeaveType leaveType = new LeaveType();
                        leaveType.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtLeaveType.Text = leaveType.LeaveTypeName;
                        txtBalance.Text = leaveType.Balance.ToString();
                        if (leaveType.Deduction == 1)
                        {
                            cbDeduction.Checked = true;
                            txtDays.Text = leaveType.DeductionValue.ToString();
                        }
                        else
                        {
                            cbDeduction.Checked = false;
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
            LeaveType leaveType = new LeaveType();
            leaveType.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            leaveType.LeaveTypeName = txtLeaveType.Text;
            leaveType.OperatorID = 1;// change it when create users
            leaveType.Balance = Convert.ToInt32(txtBalance.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            leaveType.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbDeduction.Checked)
            {
                leaveType.Deduction = 1;
                leaveType.DeductionValue = Convert.ToInt32(txtDays.Text);
            }
            else
            {
                leaveType.Deduction = 0;
                leaveType.DeductionValue = 0;
            }
            int id = leaveType.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/LeaveTypes.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/AddLeaveType.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            LeaveType leaveType = new LeaveType();
            leaveType.LeaveTypeName = txtLeaveType.Text;
            
            leaveType.Balance = Convert.ToInt32(txtBalance.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            leaveType.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbDeduction.Checked)
            {
                leaveType.Deduction = 1;
                leaveType.DeductionValue = Convert.ToInt32(txtDays.Text);
            }
            else
            {
                leaveType.Deduction = 0;
                leaveType.DeductionValue = 0;
            }
            int id = leaveType.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/LeaveTypes.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/AddLeaveType.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/LeaveTypes.aspx");
        }
        protected void cbDeduction_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeduction.Checked)
            {
                lblDays.Visible = true;
                lblDayValue.Visible = true;
                txtDays.Visible = true;
            }
            else
            {

                lblDays.Visible = false;
                lblDayValue.Visible = false;
                txtDays.Visible = false;
            }
        }
    }
}