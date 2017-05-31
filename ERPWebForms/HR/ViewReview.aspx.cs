using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewReview : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewReview, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Review review = new Review();
                        review.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlEmp.Text = review.EmpID.ToString();
                        ddlSupervisor.Text = review.SupervisorID.ToString();
                        txtStartDate.Text = review.StartDate.ToShortDateString();
                        txtEndDate.Text = review.EndTime.ToShortDateString();
                        txtDueDate.Text = review.DueDate.ToShortDateString();
                        ASPxRatingControl1.Value = review.Reviews;
                        grid.DataSource = review.ReviewKPIS;
                        grid.DataBind();
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
            Response.Redirect("~/HR/CreateReview.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Reviews.aspx");
        }
    }
}