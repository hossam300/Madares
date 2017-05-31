using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class HRMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            lbluserName.Text = myCookie.Values["username"].ToString(); 
        }
        protected void btnArabic_Click(object sender, EventArgs e)
        {
         
            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "ar-EG");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);
            //   Session["lang"] = "ar-EG";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btnEnglish_Click(object sender, EventArgs e)
        {
            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "en-GB");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);

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