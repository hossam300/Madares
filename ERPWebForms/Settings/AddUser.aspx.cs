using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class AddUser : BasePage
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
                        txtUserName.Enabled = false;
                        RequiredFieldValidator1.Enabled = false;
                        txtPassword.Text = user.password;
                        txtConfirmPassword.Text = user.password;
                        ddlRole.SelectedValue = user.RoleID.ToString();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/Users.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserSecurity us = new UserSecurity();
            int id = 0;
            if (Request.QueryString["id"].ToString() != null)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    us.EditUser(id, txtPassword.Text, int.Parse(ddlRole.SelectedValue.ToString()));
                    if (id>0)
                    {
                        Response.Redirect("~/Settings/Users.aspx?Alert=success");
                    }
                  
                }
                else
                {
                    if (!us.UserNameExist(txtUserName.Text))
                    {
                     id = us.addUser(txtUserName.Text, txtPassword.Text, int.Parse(ddlRole.SelectedValue.ToString()));
                    if (id > 0)
                     {
                        Response.Redirect("~/Settings/Users.aspx?Alert=success");
                        }
                    }
                     else
                          {
                               error.Visible = true;
                              error.Text = "UserName already Exist ";
                           }
                }
            }
           

           
            }
           
        }
    }
