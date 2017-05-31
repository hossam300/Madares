using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewBank, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Bank bank = new Bank();
                        bank.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        lblBankID.Text = bank.ID.ToString();
                        lblBankName.Text = bank.BankName;
                        lblAccountNumber.Text = bank.AccountNumber;
                        txtDescription.Text = bank.Description;
                        lblCurrentBalance.Text = bank.CurrentBalance.ToString();
                        lblstartingBalance.Text = bank.InitialBalance.ToString();
                        lblCreationDate.Text = bank.CreationDate.ToShortDateString();
                        lblLastModifiedDate.Text = bank.LastModifiedDate.ToShortDateString();
                    }
                }
            }
        }
        protected void btnEdite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/AddBank.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/Banks.aspx");
        }
    }
}