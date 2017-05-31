using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewFinancialYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewFinancialYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {

                FinancialYear year = new FinancialYear();
                year.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                lblYearID.Text = year.ID.ToString();
                lblYearName.Text = year.Name;
                lblYearStartDate.Text = year.StartDate.ToShortDateString();
                lblYearEndDate.Text = year.EndDate.ToShortDateString();
                txtDes.Text = year.Description;

                lblLastModifiedDate.Text = year.LastModifiedDate.ToShortDateString();
            }
        }
        protected void btnEdite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/CreateFinancialYear.aspx?id=" + Request.QueryString["id"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/FinancialYears.aspx");
        }
    }
}