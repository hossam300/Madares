using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsOrder
    {
        public Order get(int id)
        {
            string sql = "Select * From Inv_Orders Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Order order = new Order();
            order.ID = id;
            order.OrderCode = dt.Rows[0]["OrderCode"].ToString();
            order.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"].ToString());
            order.DeliveryDate = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"].ToString());
            order.Status = Convert.ToInt32(dt.Rows[0]["Status"].ToString());
            order.RejectReason = dt.Rows[0]["RejectionReason"].ToString();
            order.Remarks = dt.Rows[0]["Remarks"].ToString();
            order.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            order.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            order.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            order.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return order;
        }
        public List<Order> getList()
        {
            List<Order> orders = new List<Order>();
            string sql = "Select * From Inv_Orders";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Order order = new Order();
                order.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                order.OrderCode = dt.Rows[i]["OrderCode"].ToString();
                order.SupplierID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                order.DeliveryDate = Convert.ToDateTime(dt.Rows[i]["DeliveryDate"].ToString());
                order.Status = Convert.ToInt32(dt.Rows[i]["Status"].ToString());
                order.RejectReason = dt.Rows[i]["RejectionReason"].ToString();
                order.Remarks = dt.Rows[i]["Remarks"].ToString();
                order.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                order.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                order.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                order.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                orders.Add(order);
            }
            return orders;
        }
        public int insert(Order order)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@OrderCode", order.OrderCode, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@SupplierID", order.SupplierID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@DeliveryDate", order.DeliveryDate, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@Status", order.Status, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@RejectReason", order.RejectReason, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Remarks", order.Remarks, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@Active", order.Active, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@OperatorID", order.OperatorID, SqlDbType.Int, 50);
            string sql = "INSERT INTO [dbo].[Inv_Orders]([OrderCode],[SupplierID],[DeliveryDate],[Status],[RejectionReason],[Remarks],[CreationDate],[LastModifiedDate],[OperatorID],[Active]) Values " +
                "(@OrderCode,@SupplierID,@DeliveryDate,@Status,@RejectionReason,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                sql = "select max(id)as lastID from Inv_Orders";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        SqlParameter[] param2 = new SqlParameter[10];
                        param2[0] = DataAccess.AddParamter("@OrderID", id, SqlDbType.Int, 50);
                        param2[1] = DataAccess.AddParamter("@ProductWarehouseID", order.OrderItems[i].ProductWarehouseID, SqlDbType.Int, 50);
                        param2[2] = DataAccess.AddParamter("@Active", order.OrderItems[i].Active, SqlDbType.Int, 50);
                        param2[3] = DataAccess.AddParamter("@Cost", order.OrderItems[i].Cost, SqlDbType.Int, 50);
                        param2[4] = DataAccess.AddParamter("@Amount", order.OrderItems[i].Amount, SqlDbType.Float, 50);
                        param2[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                        param2[6] = DataAccess.AddParamter("@OperatorID", order.OperatorID, SqlDbType.Int, 50);
                        param2[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                        sql = "Insert Into Inv_OrderItems (OrderID,ProductWarehouseID,Active,Cost,Amount,CreationDate,LastModifiedDate,OperatorID) " +
                            "Values (@OrderID,@ProductWarehouseID,1,@Cost,@Amount,@CreationDate,@LastModifiedDate,@OperatorID)";
                        int res2 = DataAccess.ExecuteSQLNonQuery(sql, param2);

                        if (res2 > 0)
                        {
                            UpdateProductWarehouseQuantity(order.OrderItems[i].ProductWarehouseID, order.OrderItems[i].Amount);
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
                sql = "Update [Inv_Orders] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Orders] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From  [Inv_Orders] Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}