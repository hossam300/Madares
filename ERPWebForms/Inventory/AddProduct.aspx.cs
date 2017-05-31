using DevExpress.Web;
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
    public partial class AddProduct : BasePage
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

                //for (int i = 0; i < 23; i++)
                //{
                //    DataRow aRow = table.NewRow();
                //    aRow["ID"] = i;
                //    aRow["Name"] = String.Format("Name{0}", i);

                //    table.Rows.Add(aRow);
                //}
                Session["ProductWarehouse"] = table;
            }
            return table;
        }
        public Int32 GetLastKey()
        {
            DataTable table = GetTable();

            Int32 max = 0;
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ID"]) > max)
                    max = Convert.ToInt32(row["ID"]);
            }
            return max;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            grid.DataSource = GetTable();
            grid.KeyFieldName = "ID";
            grid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Security 
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //else
            //{
            //    if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddBank, Request.Cookies["user"]["Permission"].ToString()))
            //        Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            //}
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
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                      //  table = GetTable();
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["ProductWarehouse"] = table;

            e.Cancel = true;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["WarehouseID"], e.NewValues["Quantity"], e.NewValues["Cost"], e.NewValues["Price"], e.NewValues["Barcode"] });

            Session["ProductWarehouse"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["WarehouseID"] = e.NewValues["WarehouseID"];
            found["Quantity"] = e.NewValues["Quantity"];
            found["Cost"] = e.NewValues["Cost"];
            found["Price"] = e.NewValues["Price"];
            found["Barcode"] = e.NewValues["Barcode"];
            Session["ProductWarehouse"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            InvProduct product = new InvProduct();
            product.Name = txtName.Text;
            product.SerialNumber = txtSerialNum.Text;
            product.Cost = Convert.ToDouble(txtCost.Text);
            product.Price = Convert.ToDouble(txtPrice.Text);
            product.Barcode = txtBarcode.Text;
            product.Category = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            product.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            product.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            product.LowQuantity = Convert.ToInt32(txtLowQuantity.Text);
            DataTable dt = Session["ProductWarehouse"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductWatehouse productWarehouse = new ProductWatehouse();
                productWarehouse.WarehouseID = Convert.ToInt32(dt.Rows[i]["WearhouseID"].ToString());
                productWarehouse.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                productWarehouse.Cost = Convert.ToDouble(dt.Rows[i]["Cost"].ToString());
                productWarehouse.Price = Convert.ToDouble(dt.Rows[i]["Price"].ToString());
                productWarehouse.Barcode = dt.Rows[i]["Barcode"].ToString();
                productWarehouse.Active = 1;
                product.productWatehouse.Add(productWarehouse);
            }
            int res = new clsProduct().update(Convert.ToInt32(Request.QueryString["id"].ToString()), product);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Products.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddProduct.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InvProduct product = new InvProduct();
            product.Name = txtName.Text;
            product.SerialNumber = txtSerialNum.Text;
            product.Cost = Convert.ToDouble(txtCost.Text);
            product.Price = Convert.ToDouble(txtPrice.Text);
            product.Barcode = txtBarcode.Text;
            product.Category = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            product.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            product.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            product.LowQuantity = Convert.ToInt32(txtLowQuantity.Text);
            DataTable dt = Session["ProductWarehouse"] as DataTable;
            List<ProductWatehouse> productWarehouses= new List<ProductWatehouse>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductWatehouse productWarehouse = new ProductWatehouse();
                productWarehouse.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"].ToString());
                productWarehouse.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                productWarehouse.Cost = Convert.ToDouble(dt.Rows[i]["Cost"].ToString());
                productWarehouse.Price = Convert.ToDouble(dt.Rows[i]["Price"].ToString());
                productWarehouse.Barcode = dt.Rows[i]["Barcode"].ToString();
                productWarehouse.Active = 1;
                productWarehouses.Add(productWarehouse);
            }
            product.productWatehouse = productWarehouses;
            int res = new clsProduct().insert(product);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Products.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddProduct.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Products.aspx");
        }

       
    }
}