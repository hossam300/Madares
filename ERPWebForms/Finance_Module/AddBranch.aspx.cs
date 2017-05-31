using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddBranch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddBranch, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
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
                        Branch branch = new Branch();
                        branch.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtBranchName.Text = branch.Name;
                        txtBranchphone.Text = branch.Phone;
                        txtlname.Text = branch.Description;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/Branches.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
             
            Branch branch = new Branch();
            branch.Name = txtBranchName.Text;
            branch.Phone = txtBranchphone.Text;
            branch.Description = txtlname.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            branch.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = branch.save();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Branches.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddBranch.aspx?id=0&&alret=notpass");
            }

        }




        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Branch branch = new Branch();
            branch.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            branch.Name = txtBranchName.Text;
            branch.Phone = txtBranchphone.Text;
            branch.Description = txtlname.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            branch.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = branch.update();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Branches.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddBranch.aspx?id=0&&alret=notpass");
            }
        }
    }
}