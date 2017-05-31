using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsRestock
    {
        public Restock get(int id)
        {
            string sql = "Select * From Inv_Restock Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Restock restock = new Restock();
            restock.ID = id;
            restock.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
            restock.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"].ToString());
            restock.WarehouseID = Convert.ToInt32(dt.Rows[0]["WarehouseID"].ToString());
            restock.TotalCost = Convert.ToDouble(dt.Rows[0]["TotalCost"].ToString());
            restock.UnitCost = Convert.ToDouble(dt.Rows[0]["UnitCost"].ToString());
            restock.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
            restock.Remarks = dt.Rows[0]["Remarks"].ToString();
            restock.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            restock.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            restock.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            restock.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return restock;
        }
        public List<Restock> getList()
        {
            List<Restock> restocks = new List<Restock>();
            string sql = "Select * From Inv_Restock ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Restock restock = new Restock();
                restock.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                restock.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"].ToString());
                restock.SupplierID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                restock.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"].ToString());
                restock.TotalCost = Convert.ToDouble(dt.Rows[i]["TotalCost"].ToString());
                restock.UnitCost = Convert.ToDouble(dt.Rows[i]["UnitCost"].ToString());
                restock.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                restock.Remarks = dt.Rows[i]["Remarks"].ToString();
                restock.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                restock.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                restock.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                restock.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                restocks.Add(restock);
            }
            return restocks;
        }
        public int insert(Restock restock)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = DataAccess.AddParamter("@ProductID", restock.ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@SupplierID", restock.SupplierID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@WarehouseID", restock.WarehouseID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@TotalCost", restock.TotalCost, SqlDbType.Float, 50);
            param[4] = DataAccess.AddParamter("@UnitCost", restock.UnitCost, SqlDbType.Float, 50);
            param[5] = DataAccess.AddParamter("@Quantity", restock.Quantity, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@Remarks", restock.Remarks, SqlDbType.NVarChar, 500);
            param[7] = DataAccess.AddParamter("@Active", restock.Active, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[10] = DataAccess.AddParamter("@OperatorID", restock.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_Restock (ProductID,SupplierID,WarehouseID,TotalCost,UnitCost,Quantity,Remarks,CreationDate,LastModifiedDate,OperatorID,Active) Values (@ProductID,@SupplierID,@WarehouseID,@TotalCost,@UnitCost,@Quantity,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                UpdateProductWarehouse(restock.ProductID, restock.WarehouseID, restock.UnitCost, restock.Quantity, restock.OperatorID);
            }
            return res;
        }

        private void UpdateProductWarehouse(int ProductID, int WarehouseID, double UnitCost, int Quantity, int OperatorID)
        {
            string sql = "Select ID,Quantity from Inv_ProductWearhous Where ProductID=" + ProductID + " And WarehouseID=" + WarehouseID;
            DataTable dtID = DataAccess.ExecuteSQLQuery(sql);
            int id = Convert.ToInt32(dtID.Rows[0]["ID"].ToString());
            int quantity = Convert.ToInt32(dtID.Rows[0]["Quantity"].ToString());
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@ProductID", ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@WarehouseID", WarehouseID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@UnitCost", UnitCost, SqlDbType.Float, 50);
            param[3] = DataAccess.AddParamter("@Quantity", (Quantity + quantity), SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", OperatorID, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            sql = "Update Inv_ProductWearhous Set UnitCost=@Cost,Quantity=@Quantity,OperatorID=@OperatorID,LastModifiedDate=@LastModifiedDate Where ID=@ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);
        }
        public int update(int id, Restock restock)
        {
            string sql = "Select Quantity From Inv_Restock Where ID=" + id;
            DataTable dtOldQuantity = DataAccess.ExecuteSQLQuery(sql);
            int oldQuantity = Convert.ToInt32(dtOldQuantity.Rows[0]["Quantity"].ToString());
            SqlParameter[] param = new SqlParameter[11];
            param[0] = DataAccess.AddParamter("@ProductID", restock.ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@SupplierID", restock.SupplierID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@WarehouseID", restock.WarehouseID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@TotalCost", restock.TotalCost, SqlDbType.Float, 50);
            param[4] = DataAccess.AddParamter("@UnitCost", restock.UnitCost, SqlDbType.Float, 50);
            param[5] = DataAccess.AddParamter("@Quantity", restock.Quantity, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@Remarks", restock.Remarks, SqlDbType.NVarChar, 500);
            param[7] = DataAccess.AddParamter("@Active", restock.Active, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[9] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[10] = DataAccess.AddParamter("@OperatorID", restock.OperatorID, SqlDbType.Int, 50);
            sql = "Update Inv_Restock Set ProductID=@ProductID,SupplierID=@SupplierID,WarehouseID=@WarehouseID,TotalCost=@TotalCost,UnitCost=@UnitCost,Quantity=@Quantity,Remarks=@Remarks,CreationDate=@CreationDate,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                if (oldQuantity == restock.Quantity)
                {
                    UpdateProductWarehouse(restock.ProductID, restock.WarehouseID, restock.UnitCost, restock.Quantity, restock.OperatorID);
                }
                else
                {
                    int newQuantity = oldQuantity - restock.Quantity;
                    UpdateProductWarehouse(restock.ProductID, restock.WarehouseID, restock.UnitCost, newQuantity, restock.OperatorID);
                }

            }
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Restock Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Restock] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Restock] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_Restock Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}