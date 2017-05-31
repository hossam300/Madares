using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsDispatch
    {
        public Dispatch get(int id)
        {
            string sql = "Select * From Inv_Dispatch Where ID=" + id;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Dispatch dispatch = new Dispatch();
            dispatch.ID = id;
            dispatch.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
            dispatch.WarehouseID = Convert.ToInt32(dt.Rows[0]["WarehouseID"].ToString());
            dispatch.StuffID = Convert.ToInt32(dt.Rows[0]["StuffID"].ToString());
            dispatch.Amount = Convert.ToInt32(dt.Rows[0]["Amount"].ToString());
            dispatch.Remarks = dt.Rows[0]["Remarks"].ToString();
            dispatch.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            dispatch.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            dispatch.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            dispatch.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return dispatch;
        }
        public List<Dispatch> getList()
        {
            List<Dispatch> dispatchs = new List<Dispatch>();
            string sql = "Select * From Inv_Dispatch ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dispatch dispatch = new Dispatch();
                dispatch.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                dispatch.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"].ToString());
                dispatch.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"].ToString());
                dispatch.StuffID = Convert.ToInt32(dt.Rows[i]["StuffID"].ToString());
                dispatch.Amount = Convert.ToInt32(dt.Rows[i]["Amount"].ToString());
                dispatch.Remarks = dt.Rows[i]["Remarks"].ToString();
                dispatch.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                dispatch.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                dispatch.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                dispatch.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                dispatchs.Add(dispatch);
            }
            return dispatchs;
        }
        public int insert(Dispatch dispatch)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@ProductID", dispatch.ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@StuffID", dispatch.StuffID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@WarehouseID", dispatch.WarehouseID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Amount", dispatch.Amount, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Remarks", dispatch.Remarks, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Active", dispatch.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", dispatch.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_Dispatch (ProductID,WarehouseID,StuffID,Amount,Remarks,CreationDate,LastModifiedDate,OperatorID,Active) Values (@ProductID,@WarehouseID,@StuffID,@Amount,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                UpdateProductWarehouse(dispatch.ProductID, dispatch.WarehouseID, dispatch.Amount, dispatch.OperatorID);
            }
            return res;
        }

        private void UpdateProductWarehouse(int ProductID, int WarehouseID, int Amount, int OperatorID)
        {
            string sql = "Select ID,Quantity from Inv_ProductWearhous Where ProductID=" + ProductID + " And WarehouseID=" + WarehouseID;
            DataTable dtID = DataAccess.ExecuteSQLQuery(sql);
            int id = Convert.ToInt32(dtID.Rows[0]["ID"].ToString());
            int quantity = Convert.ToInt32(dtID.Rows[0]["Quantity"].ToString());
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@ProductID", ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@WarehouseID", WarehouseID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Quantity", (quantity - Amount), SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", OperatorID, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            sql = "Update Inv_ProductWearhous Set Quantity=@Quantity,OperatorID=@OperatorID,LastModifiedDate=@LastModifiedDate Where ID=@ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);
        }
        public int update(int id, Dispatch dispatch)
        {
            string sql = "Select Quantity From Inv_Restock Where ID=" + id;
            DataTable dtOldQuantity = DataAccess.ExecuteSQLQuery(sql);
            int oldQuantity = Convert.ToInt32(dtOldQuantity.Rows[0]["Quantity"].ToString());
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@ProductID", dispatch.ProductID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@StuffID", dispatch.StuffID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@WarehouseID", dispatch.WarehouseID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Amount", dispatch.Amount, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Remarks", dispatch.Remarks, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Active", dispatch.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", dispatch.OperatorID, SqlDbType.Int, 50);
            sql = "Update Inv_Dispatch Set ProductID=@ProductID,WarehouseID=@WarehouseID,StuffID=@StuffID,Amount=@Amount,Remarks=@Remarks,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                if (oldQuantity == dispatch.Amount)
                {
                    UpdateProductWarehouse(dispatch.ProductID, dispatch.WarehouseID, dispatch.Amount, dispatch.OperatorID);
                }
                else
                {
                    int newQuantity =dispatch.Amount- oldQuantity ;
                    UpdateProductWarehouse(dispatch.ProductID, dispatch.WarehouseID, newQuantity, dispatch.OperatorID);
                }
            }
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Dispatch Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Dispatch] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Dispatch] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_Dispatch Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}