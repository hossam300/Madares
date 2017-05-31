using ERPWebForms.Business.Inventory.Controllers;
using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Inventory
{
    public partial class ViewRestockedItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
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
                        Restock restock = new ClsRestock().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlProduct.SelectedValue = restock.ProductID.ToString();
                        ddlSupplier.SelectedValue = restock.SupplierID.ToString();
                        ddlWarehouse.SelectedValue = restock.WarehouseID.ToString();
                        txtRemarks.Text = restock.Remarks;
                        txtQuantity.Text = restock.Quantity.ToString();
                        txtTotalCost.Text = restock.TotalCost.ToString();
                        txtUnitCost.Text = restock.UnitCost.ToString();

                        if (restock.InvoiceImage != null)
                        {
                            hrefURL.Visible = true;
                            hrefURL.HRef = restock.InvoiceImage.ToString();
                            hrefURL.InnerText = "Download";
                        }
                        btnEdit.Visible = true;
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Inventory/AddNewItemToStock.aspx?id="+id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/RestockedItems.aspx");
        }
    }
}