using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewBranch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewBranch, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {

                Branch branch = new Branch();
                branch.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                lblBranchID.Text = branch.ID.ToString();
                lblBranchName.Text = branch.Name;
                lblPhone.Text = branch.Phone;
                txtlname.Text = branch.Description;
                lblCreationDate.Text = branch.CreationDate.ToShortDateString();
                lblLastModifiedDate.Text = branch.LastModifiedDate.ToShortDateString();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/Branches.aspx");
        }
        protected void btnEdite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/AddBranch.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}