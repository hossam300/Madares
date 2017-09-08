using ERPWebForms.Business.Bus.Controllers;
using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class ViewDriver : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddParent, Request.Cookies["user"]["Permission"].ToString()))
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
                        Driver driver = new ClsDriver().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtDriverName.Text = driver.Name;
                        txtPhone.Text = driver.Phone;
                        txtLicenseNumber.Text = driver.LicenseNumber;
                        txtLicenseEndDate.Text = driver.LicenseEndDate.ToString();
                        txtDateHiring.Text = driver.DateHiring.ToString();
                        txtEndHiring.Text = driver.EndHiring.ToString();
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
            Response.Redirect("~/StudentAfair/AddDriver.aspx?id=" + id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Drivers.aspx");
        }
    }
}