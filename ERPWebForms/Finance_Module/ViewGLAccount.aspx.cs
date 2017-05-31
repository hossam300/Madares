using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewGLAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewGLAccount, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["GlAccountID"].ToString()) > 0)
            {
                GLAccount glaccount = new GLAccount();
                glaccount.get(Convert.ToInt32(Request.QueryString["GlAccountID"].ToString()));
                if (Convert.ToInt32(glaccount.ParentAcctID.ToString()) != 0)
                {
                    GLAccount glaccount2 = new GLAccount();
                    glaccount2.get(Convert.ToInt32(glaccount.ParentAcctID.ToString()));
                    lblParentGL.Text = glaccount2.Name.ToString();
                }
                else
                {
                    lblParentGL.Text = "";
                }
                lblAccountName.Text = glaccount.Name.ToString();
                lblAcctStatus.Text = glaccount.Status.ToString();
                lblBalance.Text = glaccount.Balance.ToString();

                lblacctcode.Text = glaccount.AcctCode.ToString();
                lblDesc.Text = glaccount.Description.ToString();
                ddlAcctType.SelectedValue = glaccount.AcctType.ToString();
                ASPxGridView1.DataSource = glaccount.getList(glaccount.ID);
                ASPxGridView1.DataBind();

                ASPxGridView2.DataSource = glaccount.getAcctTransactions(glaccount.ID);
                ASPxGridView2.DataBind();
            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Finance_Module/ViewGLAccount.aspx?GlAccountID=" + id);


            }
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=" + id);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["GlAccountID"].ToString());
            if (lblParentGL.Text != "")
            {
                string sql = "select ID from Fin_GLAccount where Name =N'" + lblParentGL.Text + "'";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                GLAccount glaccount = new GLAccount();
                glaccount.ParentAcctID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=" + id + "&parent=" + glaccount.ParentAcctID + "&acctType=" + ddlAcctType.SelectedValue.ToString());
            }
            Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=" + id + "&parent=" + 0 + "&acctType=" + ddlAcctType.SelectedValue.ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/GLAccounts.aspx");
        }
        protected void btncreateGlAcct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/CreateNewGLAccount.aspx?id=0&parent=" + Request.QueryString["GlAccountID"].ToString() + "&acctType=" + ddlAcctType.SelectedValue);
        }
        protected void btnExportGllacctx_Click(object sender, EventArgs e)
        {

        }
        protected void btnExportGllacctw_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportAccttransx_Click(object sender, EventArgs e)
        {

        }
        protected void btnExportAccttransw_Click(object sender, EventArgs e)
        {

        }

        protected void btncreateAccttrans_Click(object sender, EventArgs e)
        {

        }
    }
}