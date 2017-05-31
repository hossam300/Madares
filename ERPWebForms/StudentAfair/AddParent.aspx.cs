//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddParent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddParent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
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
                        Parent p = new Parent();
                        p.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtParentName.Text = p.Name;
                        txtjob.Text = p.Job;
                        txtPhone.Text = p.Phone;
                        txtAddress.Text = p.Address;
                        txtEmail.Text = p.Email;
                        txtUserName.Text = p.UserName;
                        txtUserName.Enabled = false;
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
            Parent p = new Parent();
            p.Name = txtParentName.Text;
            p.Job = txtjob.Text;
            p.Phone = txtPhone.Text;
            p.Address = txtAddress.Text;
            p.Email = txtEmail.Text;
            p.UserName = txtUserName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            p.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = p.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Parents.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddParent.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Parents.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.Name = txtParentName.Text;
            p.Job = txtjob.Text;
            p.Phone = txtPhone.Text;
            p.Address = txtAddress.Text;
            p.Email = txtEmail.Text;
            p.UserName = txtUserName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            p.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            p.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            int id = p.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Parents.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddParent.aspx?id=0&&alret=notpass");
            }
        }
    }
}