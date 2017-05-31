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
    public partial class NewSalesOrder : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["ProductWarehouse"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn ProductID = table.Columns.Add("ProductID", typeof(Int32));
                DataColumn Price = table.Columns.Add("Price", typeof(Decimal));
                DataColumn Discount = table.Columns.Add("Discount", typeof(Decimal));
                DataColumn Quantity = table.Columns.Add("Quantity", typeof(Int32));
                DataColumn Total = table.Columns.Add("Total", typeof(Decimal), "(Quantity*Price)-Discount");

                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;
                Session["SalesOrderItems"] = table;
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
                        SalesOrder salesOrder = new ClsSalesOrder().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlCustomer.SelectedValue = salesOrder.CustomerID.ToString();
                        txtDeliveryDate.Text = salesOrder.DeliveryDate.ToString();
                        txtRemarks.Text = salesOrder.Remarks.ToString();
                        for (int i = 0; i < salesOrder.SalesOrderItems.Count; i++)
                        {
                            DataRow dr = table.NewRow();
                            dr["ProductID"] = salesOrder.SalesOrderItems[i].ProductWarehouseID;
                            dr["Price"] = salesOrder.SalesOrderItems[i].Price;
                            dr["Quantity"] = salesOrder.SalesOrderItems[i].Quantity;
                            dr["Discount"] = salesOrder.SalesOrderItems[i].Discount;
                            dr["Total"] = (salesOrder.SalesOrderItems[i].Price * salesOrder.SalesOrderItems[i].Quantity) - salesOrder.SalesOrderItems[i].Discount;
                            table.Rows.Add(dr);
                        }
                        Session["SalesOrderItems"] = table;
                        //       Gbind();
                        btnSave.Visible = false;
                        btnEdit.Visible = false;
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
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["SalesOrderItems"] = table;

            e.Cancel = true;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["ProductID"], e.NewValues["Price"], e.NewValues["Quantity"],e.NewValues["Discount"], e.NewValues["Total"] });

            Session["SalesOrderItems"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["ProductID"] = e.NewValues["ProductID"];
            found["Cost"] = e.NewValues["Cost"];
            found["Quantity"] = e.NewValues["Quantity"];
            found["Discount"] = e.NewValues["Discount"];
            found["Total"] = e.NewValues["Total"];
            Session["SalesOrderItems"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "select max(id)as lastID from Inv_SalesOrder";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            int id = int.Parse(dt.Rows[0]["lastID"].ToString()) + 1;
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.OrderCode = "OP" + id;
            salesOrder.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue.ToString());
            salesOrder.DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text);
            salesOrder.Remarks = txtRemarks.Text;
            salesOrder.Active = 1;
            DataTable dt2 = Session["SalesOrderItems"] as DataTable;
            List<SalesOrderItem> salesOrderItems = new List<SalesOrderItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SalesOrderItem salesOrderItem = new SalesOrderItem();
                salesOrderItem.ProductWarehouseID = Convert.ToInt32(dt.Rows[i]["ProductID"].ToString());
                salesOrderItem.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                salesOrderItem.Price = Convert.ToDouble(dt.Rows[i]["Cost"].ToString());
                salesOrderItem.Discount = Convert.ToDouble(dt.Rows[i]["Discount"].ToString());
                salesOrderItem.Active = 1;
                salesOrderItems.Add(salesOrderItem);
            }
            salesOrder.SalesOrderItems = salesOrderItems;
            HttpCookie myCookie = Request.Cookies["user"];
            salesOrder.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsSalesOrder().insert(salesOrder);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/SalesOrders.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/NewSalesOrder.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/SalesOrders.aspx");
        }
    }
}