using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateJobCategory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateJobCategory, Request.Cookies["user"]["Permission"].ToString()))
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
                        JobCategories jobCategory = new JobCategories();
                        jobCategory.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtJobCategory.Text = jobCategory.JobCategoies;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            JobCategories jobCategory = new JobCategories();

            jobCategory.JobCategoies = txtJobCategory.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            jobCategory.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = jobCategory.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/JobCategory.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateJobCategory.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/JobCategory.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            JobCategories jobCategory = new JobCategories();
            jobCategory.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            jobCategory.JobCategoies = txtJobCategory.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            jobCategory.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = jobCategory.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/JobCategory.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateJobCategory.aspx?id=0&&alret=notpass");
            }
        }

    }
}