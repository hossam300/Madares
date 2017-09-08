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
    public partial class AddStation : BasePage
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
                        Station station = new ClsStation().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = station.Name;

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
            Station station = new Station();
            station.Name = txtName.Text;
            station.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            station.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsStation().update(Convert.ToInt32(Request.QueryString["id"].ToString()), station);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/StationList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddStation.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Station station = new Station();
            station.Name = txtName.Text;
            station.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            station.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsStation().insert(station);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/StationList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddStation.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/StationList.aspx");
        }
    }
}