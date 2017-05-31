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
    public partial class ViewOrder : BasePage
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
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = GetTable();
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
                        grid.DataSource = table;
                        grid.DataBind();
                        //       Gbind();
                        btnEdit.Visible = false;
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Inventory/NewOrder.aspx?id=" + id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Orders.aspx");
        }
    }
}