using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else 
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddBank,Request.Cookies["user"]["Permission"].ToString()))
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
                        Bank bank = new Bank();
                        bank.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtBankName.Text = bank.BankName;
                        txtAccountNumber.Text = bank.AccountNumber;
                        txtlname.Text = bank.Description;
                        txtCurrentBalance.Text = bank.CurrentBalance.ToString();
                        txtstartingBalance.Text = bank.InitialBalance.ToString();
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                        txtCurrentBalance.Text = "0";
                        txtstartingBalance.Text = "0";
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Bank bank = new Bank();
            bank.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            bank.BankName = txtBankName.Text;
            bank.AccountNumber = txtAccountNumber.Text;
            bank.Description = txtlname.Text;
            bank.CurrentBalance = Convert.ToDecimal(txtCurrentBalance.Text);
            bank.InitialBalance = Convert.ToDecimal(txtstartingBalance.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            bank.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = bank.update();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Banks.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddBank.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bank bank = new Bank();
            bank.BankName = txtBankName.Text;
            bank.AccountNumber = txtAccountNumber.Text;
            bank.Description = txtlname.Text;
            bank.CurrentBalance = Convert.ToDecimal(txtCurrentBalance.Text);
            bank.InitialBalance = Convert.ToDecimal(txtstartingBalance.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            bank.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = bank.save();
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Banks.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddBank.aspx?id=0&&alret=notpass");
            }


        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/Banks.aspx");
        }
    }
}