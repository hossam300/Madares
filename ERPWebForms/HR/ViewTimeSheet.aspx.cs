using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewTimeSheet : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewTimeSheet, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    TimeSheet ts = new TimeSheet();
                    ts.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    ddlMonth.Text = ts.Month;
                    ddlYear.Text = ts.Year;
                    DataTable dt = ts.TimeSheets;
                    grid.DataSource = dt;
                    grid.DataBind();
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            Response.Redirect("~/HR/ViewTimeSheet.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/EmployeeTS.aspx");
        }
    }
}