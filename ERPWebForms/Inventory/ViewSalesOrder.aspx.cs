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
    public partial class ViewSalesOrder : BasePage
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
                        grid.DataSource = table;
                        grid.DataBind();
                        btnEdit.Visible = false;
                    }

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Inventory/NewSalesOrder.aspx?id="+id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/SalesOrders.aspx");
        }
    }
}