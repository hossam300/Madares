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
    public partial class NewOrder : BasePage
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
                DataColumn Cost = table.Columns.Add("Cost", typeof(Decimal));
                DataColumn Quantity = table.Columns.Add("Quantity", typeof(Int32));
                DataColumn Total = table.Columns.Add("Total", typeof(Decimal), "Quantity*Cost");

                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;
                Session["OrderItems"] = table;
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
                        Order order = new ClsOrder().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlSupplier.SelectedValue = order.SupplierID.ToString();
                        txtDeliveryDate.Text = order.DeliveryDate.ToString();
                        ddlStatus.SelectedValue = order.Status.ToString();
                        txtRejectionReason.Text = order.RejectReason.ToString();
                        txtRemarks.Text = order.Remarks.ToString();
                        for (int i = 0; i < order.OrderItems.Count; i++)
                        {
                            DataRow dr = table.NewRow();
                            dr["ProductID"] = order.OrderItems[i].ProductWarehouseID;
                            dr["Cost"] = order.OrderItems[i].Cost;
                            dr["Quantity"] = order.OrderItems[i].Amount;
                            dr["Total"] = order.OrderItems[i].Cost * order.OrderItems[i].Amount;
                            table.Rows.Add(dr);
                        }
                        Session["OrderItems"] = table;
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

            Session["OrderItems"] = table;

            e.Cancel = true;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = GetTable();
            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["ProductID"], e.NewValues["Cost"], e.NewValues["Quantity"], e.NewValues["Total"] });

            Session["OrderItems"] = table;

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
            found["Total"] = e.NewValues["Total"];
            Session["OrderItems"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "select max(id)as lastID from Inv_Orders";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            int id = int.Parse(dt.Rows[0]["lastID"].ToString()) + 1;
            Order order = new Order();
            order.OrderCode = "OP" + id;
            order.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue.ToString());
            order.DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text);
            order.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString());
            order.RejectReason = txtRejectionReason.Text;
            order.Remarks = txtRemarks.Text;
            order.Active = 1;
            DataTable dt2 = Session["OrderItems"] as DataTable;
            List<OrderItem> OrderItems = new List<OrderItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.ProductWarehouseID = Convert.ToInt32(dt.Rows[i]["ProductID"].ToString());
                orderItem.Amount = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                orderItem.Cost = Convert.ToDouble(dt.Rows[i]["Cost"].ToString());

                orderItem.Active = 1;
                OrderItems.Add(orderItem);
            }
            order.OrderItems = OrderItems;
            HttpCookie myCookie = Request.Cookies["user"];
            order.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsOrder().insert(order);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Orders.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/NewOrder.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Orders.aspx");
        }
    }
}