using ERPWebForms.Business.Inventory.Controllers;
using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Inventory
{
    public partial class ViewProduct : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["ProductWarehouse"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn WarehouseID = table.Columns.Add("WarehouseID", typeof(Int32));
                DataColumn Quantity = table.Columns.Add("Quantity", typeof(Int32));
                DataColumn Cost = table.Columns.Add("Cost", typeof(Decimal));
                DataColumn Price = table.Columns.Add("Price", typeof(Decimal));
                DataColumn Barcode = table.Columns.Add("Barcode", typeof(String));
                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;
                Session["ProductWarehouse"] = table;
            }
            return table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            DataTable table = GetTable();
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
                        InvProduct product = new clsProduct().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = product.Name;
                        txtSerialNum.Text = product.SerialNumber;
                        txtInitialAmount.Text = product.StockAmount.ToString();
                        txtCost.Text = product.Cost.ToString();
                        txtPrice.Text = product.Price.ToString();
                        txtBarcode.Text = product.Barcode;
                        ddlCategory.SelectedValue = product.Category.ToString();
                        txtLowQuantity.Text = product.LowQuantity.ToString();
                        // DataTable table = GetTable();

                        for (int i = 0; i < product.productWatehouse.Count; i++)
                        {
                            Warehouse warehouse = new clsWarehouse().get(product.productWatehouse[i].WarehouseID);
                            DataRow dr = table.NewRow();
                            dr["WearhouseID"] = product.productWatehouse[i].WarehouseID;
                            dr["Wearhouse"] = warehouse.Name;
                            dr["Quantity"] = product.productWatehouse[i].Quantity;
                            dr["Cost"] = product.productWatehouse[i].Cost;
                            dr["Price"] = product.productWatehouse[i].Price;
                            dr["Barcode"] = product.productWatehouse[i].Barcode;
                            table.Rows.Add(dr);
                        }
                        Session["ProductWarehouse"] = table;
                        //       Gbind();
                        grid.DataSource = table;
                        grid.DataBind();
                        btnEdit.Visible = true;
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Inventory/AddProduct.aspx?id=" + id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Products.aspx");
        }
    }
}