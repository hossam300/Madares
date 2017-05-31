using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class ViewRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddRole, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Settings/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                //load all forms
                UserSecurity us = new UserSecurity();
                DataTable dt = us.getAllForms(1);
                chkPermissionFin.DataSource = dt;
                chkPermissionFin.DataValueField = "ID";
                chkPermissionFin.DataTextField = "FormName";
                chkPermissionFin.DataBind();
                DataTable dt2 = us.getAllForms(2);
                chkPermissionHR.DataSource = dt2;
                chkPermissionHR.DataValueField = "ID";
                chkPermissionHR.DataTextField = "FormName";
                chkPermissionHR.DataBind();
                DataTable dt3 = us.getAllForms(3);
                chkPermissionST.DataSource = dt3;
                chkPermissionST.DataValueField = "ID";
                chkPermissionST.DataTextField = "FormName";
                chkPermissionST.DataBind();
                DataTable dt4 = us.getAllForms(4);
                chkPermissionSettings.DataSource = dt4;
                chkPermissionSettings.DataValueField = "ID";
                chkPermissionSettings.DataTextField = "FormName";
                chkPermissionSettings.DataBind();
                if (Request.QueryString.AllKeys.Contains("ID"))
                {
                    if (Convert.ToInt32(Request.QueryString["ID"].ToString()) > 0)
                    {
                        //UserSecurity us =new UserSecurity();
                        us.getRole(int.Parse(Request.QueryString["ID"].ToString()));
                        txtRoleName.Text = us.RoleName;
                        ddlDefault.Text = us.DefaultURL;
                        ListItem li;
                        string[] per = us.RolePermission.Split(',');
                        for (int i = 0; i < per.Length; i++)
                        {
                            li = chkPermissionFin.Items.FindByValue(per[i].ToString());
                            if (li != null)
                                li.Selected = true;
                            li = chkPermissionHR.Items.FindByValue(per[i].ToString());
                            if (li != null)
                                li.Selected = true;
                            li = chkPermissionST.Items.FindByValue(per[i].ToString());
                            if (li != null)
                                li.Selected = true;
                            li = chkPermissionSettings.Items.FindByValue(per[i].ToString());
                            if (li != null)
                                li.Selected = true;
                        }


                    }
                }
                /* chkPermission.DataSource = dt;
                 chkPermission.DataValueField = "ID";
                 chkPermission.DataTextField = "FormName";
                 chkPermission.DataBind();*/

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/AddRole.aspx?ID=" + Request.QueryString["ID"].ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/Roles.aspx");
        }
    }
}