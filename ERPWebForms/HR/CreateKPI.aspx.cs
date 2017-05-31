using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateKPI : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateKPI, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
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
                        KPIS kpi = new KPIS();
                        kpi.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlJobTitle.SelectedValue = kpi.JobTitleID.ToString();
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
            KPIS kpi = new KPIS();
            kpi.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            kpi.JobTitleID = Convert.ToInt32(ddlJobTitle.SelectedValue);
            kpi.KeyPerformanceIndicator = txtKeyIndicator.Text;
            kpi.MinimumRating = Convert.ToInt32(txtMinimumRating.Text);
            kpi.MaximumRating = Convert.ToInt32(txtMaximumRating.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            kpi.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbDefault.Checked)
            {
                kpi.DefaultScale = 1;
            }
            else
            {
                kpi.DefaultScale = 0;
            }
            int id = kpi.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/KPI.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateKPI.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            KPIS kpi = new KPIS();
            kpi.JobTitleID = Convert.ToInt32(ddlJobTitle.SelectedValue);
            kpi.KeyPerformanceIndicator = txtKeyIndicator.Text;
            kpi.MinimumRating = Convert.ToInt32(txtMinimumRating.Text);
            kpi.MaximumRating = Convert.ToInt32(txtMaximumRating.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            kpi.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbDefault.Checked)
            {
                kpi.DefaultScale = 1;
            }
            else
            {
                kpi.DefaultScale = 0;
            }
            int id = kpi.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/KPI.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateKPI.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/KPI.aspx");
        }
    }
}