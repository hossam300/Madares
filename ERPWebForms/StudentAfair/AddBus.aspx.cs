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
    public partial class AddBus : BasePage
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
                        Buses buses = new ClsBus().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtBusNumber.Text = buses.BusNumber;
                        txtEndLicenseDate.Text = buses.EndLicenseDate.ToString();
                        txtNumberOfSeats.Text = buses.NumberOfSeats.ToString();
                        ddlBusCondition.SelectedValue = buses.BusCondition.ToString();
                        ddlDriver.SelectedValue = buses.DriverId.ToString();
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
            Buses buses = new Buses();
            buses.BusNumber = txtBusNumber.Text;
            buses.EndLicenseDate =Convert.ToDateTime(txtEndLicenseDate.Text);
            buses.NumberOfSeats = Convert.ToInt32(txtNumberOfSeats.Text);
            buses.BusCondition = ddlBusCondition.SelectedValue.ToString();
            buses.DriverId = Convert.ToInt32(ddlDriver.SelectedValue);
            buses.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            buses.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsBus().update(Convert.ToInt32(Request.QueryString["id"].ToString()), buses);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BusList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBus.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Buses buses = new Buses();
            buses.BusNumber = txtBusNumber.Text;
            buses.EndLicenseDate = Convert.ToDateTime(txtEndLicenseDate.Text);
            buses.NumberOfSeats = Convert.ToInt32(txtNumberOfSeats.Text);
            buses.BusCondition = ddlBusCondition.SelectedValue.ToString();
            buses.DriverId = Convert.ToInt32(ddlDriver.SelectedValue);
            buses.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            buses.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsBus().insert(buses);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BusList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBus.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/BusList.aspx");
        }
    }
}