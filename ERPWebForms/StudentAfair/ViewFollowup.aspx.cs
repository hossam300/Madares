using ERPWebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class ViewFollowup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewStudent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
        }

        protected void btnreplay_Click(object sender, EventArgs e)
        {
            FollowUpsApiModel f = new FollowUpsApiModel();
            f.FollowUpID = Convert.ToInt32(Request.QueryString["id"].ToString());
             HttpCookie myCookie = Request.Cookies["user"];
            f.Operator = myCookie.Values["username"].ToString();
            f.Replay = ASPxMemo1.Text;
            f.save();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Students.aspx");
        }
    }
}