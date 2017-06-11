using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateDeduction : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateDeduction, Request.Cookies["user"]["Permission"].ToString()))
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
                        Bonuses bonus = new Bonuses();
                        bonus.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlEmp.SelectedValue = bonus.EmpID.ToString();
                        ddlType.SelectedValue = bonus.Type.ToString();
                        txtAmount.Text = bonus.Value.ToString();
                        ddlMonth.SelectedValue = bonus.Month.ToString();
                        ddlYear.SelectedValue = bonus.Year.ToString();
                        ddlManger.SelectedValue = bonus.Manger.ToString();
                        ddlprecentageFrom.SelectedValue = bonus.PrecentageFrom.ToString();
                        txtResone.Text = bonus.Reason.ToString();
                        txtNumberOfDays.Text = bonus.NumberOfDays.ToString();
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
            Bonuses bonus = new Bonuses();
            bonus.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            bonus.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            bonus.Type = Convert.ToInt32(ddlType.SelectedValue.ToString());
            bonus.Value = Convert.ToDecimal(txtAmount.Text);
            bonus.Nature = 0;//Nature=0 it's a Deductions
            HttpCookie myCookie = Request.Cookies["user"];
            bonus.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            bonus.Month = Convert.ToInt32(ddlMonth.SelectedValue.ToString());
            bonus.Year = Convert.ToInt32(ddlYear.SelectedValue.ToString());
            bonus.Manger = Convert.ToInt32(ddlManger.SelectedValue.ToString());
            if (ddlType.SelectedValue == "1")
            {
                bonus.PrecentageFrom = Convert.ToInt32(ddlprecentageFrom.SelectedValue.ToString());
                bonus.NumberOfDays = 0;
            }
            else if (ddlType.SelectedValue == "3")
            {
                bonus.PrecentageFrom = 0;
                bonus.NumberOfDays = Convert.ToInt32(txtNumberOfDays.Text);
            }
            else
            {
                bonus.PrecentageFrom = 0;
                bonus.NumberOfDays = 0;
            }
            bonus.Reason = txtResone.Text;
            int id = bonus.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/Deductions.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateDeduction.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bonuses bonus = new Bonuses();

            bonus.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            bonus.Type = Convert.ToInt32(ddlType.SelectedValue.ToString());
       
            bonus.Nature = 0;//Nature=0 it's a Deductions
            HttpCookie myCookie = Request.Cookies["user"];
            bonus.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            bonus.Month = Convert.ToInt32(ddlMonth.SelectedValue.ToString());
            bonus.Year = Convert.ToInt32(ddlYear.SelectedValue.ToString());
            bonus.Manger = Convert.ToInt32(ddlManger.SelectedValue.ToString());
            if (ddlType.SelectedValue == "1")
            {
                bonus.Value = Convert.ToDecimal(txtAmount.Text);
                bonus.PrecentageFrom = Convert.ToInt32(ddlprecentageFrom.SelectedValue.ToString());
                bonus.NumberOfDays = 0;
            }
            else if (ddlType.SelectedValue == "3")
            {
                bonus.Value = 0;
                bonus.PrecentageFrom = 0;
                bonus.NumberOfDays =Convert.ToInt32(txtNumberOfDays.Text);
            }
            else
            {
                bonus.Value = Convert.ToDecimal(txtAmount.Text);
                bonus.PrecentageFrom = 0;
                bonus.NumberOfDays = 0;
            }
            bonus.Reason = txtResone.Text;
            int id = bonus.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/Deductions.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateDeduction.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Deductions.aspx");
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "1")
            {
                lblprecentageFrom.Visible = true;
                ddlprecentageFrom.Visible = true;
                lblNumberOfDays.Visible = false;
                txtNumberOfDays.Visible = false;
            }
            else if (ddlType.SelectedValue == "3")
            {
                lblNumberOfDays.Visible = true;
                txtNumberOfDays.Visible = true;
                lblprecentageFrom.Visible = false;
                ddlprecentageFrom.Visible = false;
                txtAmount.Visible = false;
                lblAmount.Visible = false;

            }
            else
            {
                lblNumberOfDays.Visible = false;
                txtNumberOfDays.Visible = false;
                lblprecentageFrom.Visible = false;
                ddlprecentageFrom.Visible = false;
            }
        }
    }
}