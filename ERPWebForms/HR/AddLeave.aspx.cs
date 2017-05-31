using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class AddLeave : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddLeave, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                if (Request.QueryString["alert"] == "balanceover")
                {
                    Response.Write("<script>alert('رصيد الاجازات لا يكفى');</script>");
                }
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Leave leaves = new Leave();
                        leaves.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlEmp.SelectedValue = leaves.EmpID.ToString();
                        ddlLeaveType.Text = leaves.LeaveTypeID.ToString();
                        txtfrom.Text = leaves.FromDate.ToShortDateString();
                        txtTo.Text = leaves.ToDate.ToShortDateString();
                        txtComment.Text = leaves.Comment;

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
            Leave leaves = new Leave();
            leaves.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            leaves.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            leaves.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue.ToString());
            leaves.FromDate = Convert.ToDateTime(txtfrom.Text);
            leaves.ToDate = Convert.ToDateTime(txtTo.Text);
            leaves.Comment = txtComment.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            leaves.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (leaves.overBalance(leaves.EmpID, leaves.LeaveTypeID))
            {
                Response.Redirect("~/HR/AddLeave.aspx?id=0&&alert=balanceover");
            }
            else
            {
                int id = leaves.update();
                if (id > 0)
                {
                    Response.Redirect("~/HR/Leaves.aspx?alert=success");
                }
                else
                {
                    Response.Redirect("~/HR/AddLeave.aspx?id=0&&alret=notpass");
                }

            }


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Leave leaves = new Leave();
            leaves.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            leaves.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue.ToString());
            leaves.FromDate = Convert.ToDateTime(txtfrom.Text);
            leaves.ToDate = Convert.ToDateTime(txtTo.Text);
            leaves.Comment = txtComment.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            leaves.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (leaves.overBalance(leaves.EmpID, leaves.LeaveTypeID))
            {
                Response.Redirect("~/HR/AddLeave.aspx?id=0&&alert=balanceover");
            }
            else
            {
                int id = leaves.save();
                if (id > 0)
                {
                    Response.Redirect("~/HR/Leaves.aspx?alert=success");
                }
                else
                {
                    Response.Redirect("~/HR/AddLeave.aspx?id=0&&alret=notpass");
                }

            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Leaves.aspx");
        }
        protected void btncalculate_Click(object sender, EventArgs e)
        {
            if (txtfrom.Text != "" && txtTo.Text != "")
            {
                DateTime dtfrom = DateTime.ParseExact(txtfrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtTo = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                lblduration.Text = Convert.ToString(dtTo.Day - dtfrom.Day);
                lbldays.Visible = true;
                lblduration.ForeColor = Color.Black;
            }
            else
            {
                lblduration.Text = "Check Dates";
                lblduration.ForeColor = Color.Red;
            }
        }
    }
}