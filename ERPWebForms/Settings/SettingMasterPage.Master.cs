using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class SettingMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            lbluserName.Text = myCookie.Values["username"].ToString(); 
        }

        protected void btnArabic_Click(object sender, EventArgs e)
        {

            Session["lang"] = "ar-EG";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btnEnglish_Click(object sender, EventArgs e)
        {

            Session["lang"] = "en-GB";
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Value = "user";
            cookie.Expires = DateTime.Now.AddDays(-2);
            Response.SetCookie(cookie);
            Response.Redirect("~/Default.aspx");
        }
    }
}