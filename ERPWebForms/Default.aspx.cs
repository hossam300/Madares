using ERPWebForms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Request.QueryString["res"] == "NotAuthonticated")
               Response.Write("<script>alert('مستخدم غير مصرح له');</script>");

        }

        protected void btnlongin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                UserSecurity user = new UserSecurity();
                DataTable dt = new DataTable();
                DataTable permission = new DataTable();
                string url = "";
                if (user.login(UserName.Text, Password.Text, out dt))
                {
                    
                    HttpCookie usercookie = new HttpCookie("user");
                    usercookie.Values.Add("userid", dt.Rows[0]["user_id"].ToString());
                    usercookie.Values.Add("username", dt.Rows[0]["name"].ToString());
                    usercookie.Values.Add("Permission", dt.Rows[0]["Permission"].ToString());
                    url = dt.Rows[0]["DefaultURL"].ToString();
                    usercookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(usercookie);
                    Response.Redirect("~/Finance_Module/Default");
                }
                else
                    Response.Redirect("~/Default.aspx?res=NotAuthonticated");

            }
            
        }
    }
}