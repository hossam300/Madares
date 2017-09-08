using ERPWebForms.Business.Bus.Controllers;
using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class ViewBusLine : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["TableBusLine"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    DataTable dt = new ClsBusLine().GetBusLineStation(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    grid.DataSource = dt;
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    DataColumn colid = dt.Columns["ID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;
                    Session["TableBusLine"] = dt;
                    btnEdit.Visible = true;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddClass, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    BusLine busLine = new ClsBusLine().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtName.Text = busLine.Name;
                    ddlStartStation.SelectedValue = busLine.StartStationId.ToString();
                    ddlSupervisorId.SelectedValue = busLine.SupervisorId.ToString();
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/AddBusLine.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) );
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/BusLineList.aspx");
        }
    }
}