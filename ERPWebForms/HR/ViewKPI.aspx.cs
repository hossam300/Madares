using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewKPI : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewKPI, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        KPIS kpi = new KPIS();
                        kpi.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        Jobtitle title = new Jobtitle();
                        title.get(kpi.JobTitleID);
                        ddlJobTitle.Text = title.JobTitle;
                        txtKeyIndicator.Text = kpi.KeyPerformanceIndicator;
                        txtMaximumRating.Text = kpi.MaximumRating.ToString();
                        txtMinimumRating.Text = kpi.MinimumRating.ToString();
                        if (kpi.DefaultScale == 1)
                        {
                            cbDefault.Checked = true;
                        }
                        else
                        {
                            cbDefault.Checked = false;
                        }

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
            Response.Redirect("~/HR/CreateKPI.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/KPI.aspx");
        }
    }
}