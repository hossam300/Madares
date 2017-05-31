using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsSalesOrder
    {
        public SalesOrder get(int id)
        {
            string sql = "Select * From Inv_SalesOrder Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            SalesOrder salesorder = new SalesOrder();
            salesorder.ID = id;
            salesorder.OrderCode = dt.Rows[0]["OrderCode"].ToString();
            salesorder.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            salesorder.DeliveryDate = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"].ToString());
            salesorder.Remarks = dt.Rows[0]["Remarks"].ToString();
            salesorder.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            salesorder.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            salesorder.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            salesorder.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return salesorder;
        }
        public List<SalesOrder> getList()
        {
            List<SalesOrder> SalesOrders = new List<SalesOrder>();
            string sql = "Select * From Inv_SalesOrder";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SalesOrder salesorder = new SalesOrder();
                salesorder.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                salesorder.OrderCode = dt.Rows[0]["OrderCode"].ToString();
                salesorder.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                salesorder.DeliveryDate = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"].ToString());
                salesorder.Remarks = dt.Rows[0]["Remarks"].ToString();
                salesorder.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
                salesorder.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
                salesorder.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
                salesorder.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
                SalesOrders.Add(salesorder);
            }
            return SalesOrders;
        }
        public int insert(SalesOrder salesOrder)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = DataAccess.AddParamter("@OrderCode", salesOrder.OrderCode, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@CustomerID", salesOrder.CustomerID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@DeliveryDate", salesOrder.DeliveryDate, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@Remarks", salesOrder.Remarks, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@Active", salesOrder.Active, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@OperatorID", salesOrder.OperatorID, SqlDbType.Int, 50);
            string sql = "INSERT INTO [dbo].[Inv_SalesOrder]([OrderCode],[CustomerID],[DeliveryDate],[Remarks],[CreationDate],[LastModifiedDate],[OperatorID],[Active]) Values " +
                "(@OrderCode,@CustomerID,@DeliveryDate,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                sql = "select max(id)as lastID from Inv_SalesOrder";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                    for (int i = 0; i < salesOrder.SalesOrderItems.Count; i++)
                    {
                        SqlParameter[] param2 = new SqlParameter[10];
                        param2[0] = DataAccess.AddParamter("@OrderID", id, SqlDbType.Int, 50);
                        param2[1] = DataAccess.AddParamter("@ProductWarehouseID", salesOrder.SalesOrderItems[i].ProductWarehouseID, SqlDbType.Int, 50);
                        param2[2] = DataAccess.AddParamter("@Active", salesOrder.SalesOrderItems[i].Active, SqlDbType.Int, 50);
                        param2[3] = DataAccess.AddParamter("@Price", salesOrder.SalesOrderItems[i].Price, SqlDbType.Int, 50);
                        param2[4] = DataAccess.AddParamter("@Quantity", salesOrder.SalesOrderItems[i].Quantity, SqlDbType.Float, 50);
                        param2[4] = DataAccess.AddParamter("@Discount", salesOrder.SalesOrderItems[i].Discount, SqlDbType.Float, 50);
                        param2[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                        param2[6] = DataAccess.AddParamter("@OperatorID", salesOrder.OperatorID, SqlDbType.Int, 50);
                        param2[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                        sql = "Insert Into Inv_SalesOrderItems (OrderID,ProductWarehouseID,Active,Price,Quantity,Discount,CreationDate,LastModifiedDate,OperatorID) " +
                           "Values (@OrderID,@ProductWarehouseID,1,@Price,@Quantity,@Discount,@CreationDate,@LastModifiedDate,@OperatorID)";
                        int res2 = DataAccess.ExecuteSQLNonQuery(sql, param2);

                        if (res2 > 0)
                        {
                            UpdateProductWarehouseQuantity(salesOrder.SalesOrderItems[i].ProductWarehouseID, salesOrder.SalesOrderItems[i].Quantity);
                        }
                    }
                }
            }
            return res;
        }

        private void UpdateProductWarehouseQuantity(int ProductWarehouseID, int Amount)
        {
            string sql = "Select Quantity From Inv_ProductWearhous Where ID=" + ProductWarehouseID;
            DataTable dtQuantity = DataAccess.ExecuteSQLQuery(sql);
            int oldQuantity = Convert.ToInt32(dtQuantity.Rows[0]["Quantity"].ToString());
            int quantity = oldQuantity - Amount;
            sql = "Update Inv_ProductWearhous Set Quantity=" + quantity + " Where ID=" + ProductWarehouseID;
            DataAccess.ExecuteSQLNonQuery(sql);
        }
        public int update(int id, Order order)
        {
            int res = 0;
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Orders Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_SalesOrder] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_SalesOrder] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From  [Inv_SalesOrder] Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}