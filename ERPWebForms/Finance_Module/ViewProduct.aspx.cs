using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ERPWebForms.Finance_Module
{
    public partial class ViewProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewProduct, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["ID"].ToString()) > 0)
            {
                Product product = new Product();
                product.get(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                lblProductID.Text = product.ID.ToString();
                lblProductName.Text = product.Name.ToString();
                lblCreationDate.Text = product.CreationDate.ToShortDateString();
                lblLastModifiedDate.Text = product.LastModifiedDate.ToShortDateString();
                lblType.Text = product.TypeID.ToString();
                lblCost.Text = product.Cost.ToString();
                lblPrice.Text = product.Price.ToString();
                ProductPriceItems PPI = new ProductPriceItems();
                ASPxGridView2.DataSource = PPI.getByProductID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                ASPxGridView2.DataBind();

                DataTable dt = product.getProductCustomers(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                ASPxGridView1.DataSource = dt;
                ASPxGridView1.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx?id=" + Request.QueryString["ID"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
        protected void ASPxGridView2_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
        protected void ASPxGridView2_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }

        protected void btnExportpriceitemx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportpriceitemw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
        protected void btnNewCustomerItem_Click(object sender, EventArgs e)
        {

        }
        protected void btnExportCustomerItemx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter2.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportCustomerItemw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter2.WriteRtfToResponse();
        }
    }

}