using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class CreateNewGLAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateNewGLAccount, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                if (Request.QueryString["alert"] == "AccountCodeExist")
                {
                    Response.Write("<script>alert('لم يتم الحفظ كود الحساب موجود سابقاً لا يمكن تكراره من فضلك اعد المحاولة');</script>");
                }

                if (Request.QueryString.AllKeys.Contains("id"))
                {
                    if (Request.QueryString["id"].ToString() != null)
                    {
                        if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                        {
                            GLAccount glaccount = new GLAccount();
                            glaccount.get(Convert.ToInt32(Request.QueryString["id"].ToString()));

                            if (Convert.ToInt32(glaccount.ParentAcctID.ToString()) != 0)
                            {
                                GLAccount glaccount2 = new GLAccount();
                                glaccount2.get(Convert.ToInt32(glaccount.ParentAcctID.ToString()));
                                ddlParentGL.SelectedValue = glaccount2.ID.ToString();
                            }
                            else
                            {
                                ddlParentGL.SelectedValue = "0";
                            }
                            txtAcctName.Text = glaccount.Name.ToString();
                            lstAcctStatus.SelectedValue = glaccount.Status.ToString();
                            txtBalance.Text = glaccount.Balance.ToString();
                            txtDesc.Text = glaccount.Description.ToString();
                            txtacctcode.Text = glaccount.AcctCode.ToString();
                            ddlAcctType.SelectedValue = glaccount.AcctType.ToString();
                            btnEdit.Visible = true;
                            btnSave.Visible = false;
                            lstAcctStatus.Enabled = false;
                        }
                        else
                        {
                            if (Request.QueryString.AllKeys.Contains("parent") && Request.QueryString.AllKeys.Contains("acctType"))
                            {
                                ddlParentGL.SelectedValue = Request.QueryString["parent"].ToString();
                                ddlAcctType.SelectedValue = Request.QueryString["acctType"].ToString();
                            }
                            lstAcctStatus.Enabled = true;
                            btnEdit.Visible = false;
                            btnSave.Visible = true;
                        }
                    }
                }
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GLAccount glaccount = new GLAccount();
            glaccount.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            glaccount.Name = txtAcctName.Text;
            glaccount.Status = Convert.ToInt32(lstAcctStatus.SelectedValue.ToString());
            glaccount.Balance = Convert.ToDecimal(txtBalance.Text);
            glaccount.Description = txtDesc.Text;
            glaccount.AcctCode = Convert.ToInt32(txtacctcode.Text);
            glaccount.AcctType = Convert.ToInt32(ddlAcctType.SelectedValue);
            glaccount.ParentAcctID = Convert.ToInt32(ddlParentGL.SelectedValue.ToString());
          
            if (glaccount.AccountCodeExist(Convert.ToInt32(txtacctcode.Text)))
            {
                GLAccount glaccount2 = new GLAccount();
                glaccount2.get(Convert.ToInt32(glaccount.ID));
                if (glaccount2.AcctCode != glaccount.AcctCode)
                {
                    Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=" + glaccount.ID + "&&alert=AccountCodeExist");
                }

            }
            int id = glaccount.update();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/GLAccounts.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GLAccount glaccount = new GLAccount();
            glaccount.Name = txtAcctName.Text;
            glaccount.Status = Convert.ToInt32(lstAcctStatus.SelectedValue.ToString());
            glaccount.Balance = Convert.ToDecimal(txtBalance.Text);
            glaccount.Description = txtDesc.Text;
            glaccount.OperatorID = 1;////to do
            glaccount.AcctCode = Convert.ToInt32(txtacctcode.Text);
            glaccount.AcctType = Convert.ToInt32(ddlAcctType.SelectedValue);
            glaccount.ParentAcctID = Convert.ToInt32(ddlParentGL.SelectedValue);
            if (glaccount.AccountCodeExist(Convert.ToInt32(txtacctcode.Text)))
            {
                Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?alert=AccountCodeExist");
            }
            int id = glaccount.save();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/GLAccounts.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=0&&alret=notpass");
            }



        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/GLAccounts.aspx");
        }
    }
}