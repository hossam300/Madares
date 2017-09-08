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
    public partial class AddDriver : BasePage
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
            Driver driver = new Driver();
            driver.Name = txtDriverName.Text;
            driver.Phone = txtPhone.Text;
            driver.LicenseNumber = txtLicenseNumber.Text;
            driver.LicenseEndDate = Convert.ToDateTime(txtLicenseEndDate.Text);
            driver.DateHiring = Convert.ToDateTime(txtDateHiring.Text);
            driver.EndHiring = Convert.ToDateTime(txtEndHiring.Text);
            driver.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            driver.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsDriver().update(Convert.ToInt32(Request.QueryString["id"].ToString()), driver);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/Drivers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddDriver.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.Name = txtDriverName.Text;
            driver.Phone = txtPhone.Text;
            driver.LicenseNumber = txtLicenseNumber.Text;
            driver.LicenseEndDate = Convert.ToDateTime(txtLicenseEndDate.Text);
            driver.DateHiring = Convert.ToDateTime(txtDateHiring.Text);
            driver.EndHiring = Convert.ToDateTime(txtEndHiring.Text);
            driver.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            driver.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsDriver().insert(driver);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/Drivers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddDriver.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Drivers.aspx");
        }
    }
}