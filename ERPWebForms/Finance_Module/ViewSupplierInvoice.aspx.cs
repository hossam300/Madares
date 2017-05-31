using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewSupplierInvoice : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewSupplierInvoice, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                SupplierInvoice s = new SupplierInvoice();
                s.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                txtDescription.Text = s.Description;
                txtInvoiceNumber.Text = s.InvoiceNumber.ToString();
                txtPaidAmount.Text = s.PaidAmount.ToString();
                txtRemaining.Text = s.RemainingAmount.ToString();
                txtTotalAmount.Text = s.TotalAmount.ToString();
                ddlCashGlAccount.SelectedValue = s.InvoiceGLAcct.ToString();
                ddlliabilityGlAccount.SelectedValue = s.InvoiceLiabGLAcct.ToString();
                ddlSupplier.SelectedValue = s.SupplierID.ToString();
                DataTable dt = s.getInvItems(Convert.ToInt32(Request.QueryString["id"].ToString()));
                grid.DataSource = dt;
                Session["Table"] = dt;
                grid.DataBind();

            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Response
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/SupplierInvoices.aspx");
        }
    }
}