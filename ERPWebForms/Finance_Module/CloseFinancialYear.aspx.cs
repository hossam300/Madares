using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class CloseFinancialYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CloseEducationalYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {

                FinancialYear year = new FinancialYear();
                year.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                lblYearName.Text = year.Name;
                lblYearStartDate.Text = year.StartDate.ToShortDateString();
                lblYearEndDate.Text = year.EndDate.ToShortDateString();
                lblDes.Text = year.Description;
                DataTable dt = year.getTrailBalance();
                ASPxGridView1.DataSource = dt;
                ASPxGridView1.DataBind();
            }
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Finance_Module/ViewGLAccount.aspx?GlAccountID=" + id);


            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            FinancialYear year = new FinancialYear();
            year.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
            year.CloseYear();
            Response.Redirect("~/Finance_Module/FinancialYears.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/FinancialYears.aspx");
        }
    }
}