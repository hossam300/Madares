using ERPWebForms.Business.control.Controllers;
using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddFloor : BasePage
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
                        floor floor = new Clsfloor().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = floor.Name;
                        ddlSupervisor.SelectedValue = floor.SupervisorId.ToString();
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
            floor floor = new floor();
            floor.Name = txtName.Text;
            floor.SupervisorId = Convert.ToInt32(ddlSupervisor.SelectedValue.ToString());
            floor.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            floor.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new Clsfloor().update(Convert.ToInt32(Request.QueryString["id"].ToString()), floor);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/FloorList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddFloor.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            floor floor = new floor();
            floor.Name = txtName.Text;
            floor.SupervisorId = Convert.ToInt32(ddlSupervisor.SelectedValue.ToString());
            floor.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            floor.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new Clsfloor().insert(floor);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/FloorList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddFloor.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/FloorList.aspx");
        }
    }
}