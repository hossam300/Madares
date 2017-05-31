using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Settings
{
    public partial class AddRole : BasePage
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
            if(!IsPostBack)
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
                        ddlDefault.SelectedValue = us.DefaultURL;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
         //   DataRow dr;
            string permission = "";
            for (int i = 0; i < chkPermissionFin.Items.Count; i++)
            {
                if (chkPermissionFin.Items[i].Selected)
                {
                    permission += chkPermissionFin.Items[i].Value.ToString() + ",";
                }
            }
            for (int i = 0; i < chkPermissionHR.Items.Count; i++)
            {
                if (chkPermissionHR.Items[i].Selected)
                {
                    permission += chkPermissionHR.Items[i].Value.ToString() + ",";
                }
            }
            for (int i = 0; i < chkPermissionST.Items.Count; i++)
            {
                if (chkPermissionST.Items[i].Selected)
                {
                    permission += chkPermissionST.Items[i].Value.ToString() + ",";
                }
            }
            for (int i = 0; i < chkPermissionSettings.Items.Count; i++)
            {
                if (chkPermissionSettings.Items[i].Selected)
                {
                    permission += chkPermissionSettings.Items[i].Value.ToString() + ",";
                }
            }
            if (permission.Length > 0)
                permission.Substring(0, permission.Length - 1);
            if (!Request.QueryString.AllKeys.Contains("ID"))
            {
                int id = new UserSecurity().addRole(txtRoleName.Text, ddlDefault.SelectedValue.ToString(), permission);
            }
            else
            {
                new UserSecurity().updateRole(int.Parse(Request.QueryString["ID"].ToString()), txtRoleName.Text, ddlDefault.SelectedValue.ToString(), permission);
            }
            Response.Redirect("~/Settings/Roles?res=success");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Settings/Roles.aspx");
        }
    }
}