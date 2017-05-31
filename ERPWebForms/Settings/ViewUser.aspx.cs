using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddUser, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Settings/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        UserSecurity user = new UserSecurity();
                        user.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtUserName.Text = user.userName;
                        txtPassword.Text = user.password;
                        user.getRole(user.RoleID);
                        ddlRole.Text = user.RoleName;
                        /*btnSave.Visible = false;
                        btnEdit.Visible = true;*/
                    }
                    /* else
                     {
                         btnSave.Visible = true;
                         btnEdit.Visible = false;
                     }*/
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/AddUser.aspx?id=" + Request.QueryString["ID"].ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/Users.aspx");
        }
    }
}