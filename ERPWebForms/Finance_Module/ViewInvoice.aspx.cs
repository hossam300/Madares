using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewInvoice : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewInvoice, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["GlAccountID"].ToString()) > 0)
            {
                Invoice invoice = new Invoice();
                invoice.get(Convert.ToInt32(Request.QueryString["GlAccountID"].ToString()));
                lblInvoiceID.Text = invoice.ID.ToString();
                lblInvoiceNumber.Text = invoice.InvoiceNumber.ToString();
                lblCreationDate.Text = invoice.CreationDate.ToShortDateString();
                lblLastModifiedDate.Text = invoice.LastModifiedDate.ToShortDateString();
                Customer customer = new Customer();
                customer.get(invoice.CustomerID);
                lblCustome.Text = customer.Name.ToString();
                Product product = new Product();
                product.get(invoice.ProductID);
                lblProduct.Text = product.Name.ToString();
                lblAmount.Text = invoice.Amount.ToString();
                txtDesc.Text = invoice.Description.ToString();
                grid.DataSource = invoice.InvoiceJournalEntry;
                grid.DataBind();
                //  ProductPriceItems PPI = new ProductPriceItems();
                //  ASPxGridView2.DataSource = PPI.getByProductID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                // ASPxGridView2.DataBind();
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInvoice.aspx?id=" + Request.QueryString["GlAccountID"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoices.aspx");
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
    }
}