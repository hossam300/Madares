using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class clsStoreKeeper
    {
        public StoreKeeper get(int id)
        {
            string sql = "Select * From Inv_StoreKeeper Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            StoreKeeper storeKeeper = new StoreKeeper();
            storeKeeper.ID = id;
            storeKeeper.Name = dt.Rows[0]["Name"].ToString();
            storeKeeper.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            storeKeeper.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            storeKeeper.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return storeKeeper;
        }
        public List<StoreKeeper> getList()
        {
            string sql = "Select * From Inv_StoreKeeper";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            List<StoreKeeper> storeKeepers = new List<StoreKeeper>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StoreKeeper storeKeeper = new StoreKeeper();
                storeKeeper.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                storeKeeper.Name = dt.Rows[i]["Name"].ToString();
                storeKeeper.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                storeKeeper.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                storeKeeper.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                storeKeepers.Add(storeKeeper);
            }
            return storeKeepers;
        }
        public int insert(StoreKeeper storeKeeper)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DataAccess.AddParamter("@Name", storeKeeper.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@OperatorID", storeKeeper.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_StoreKeeper(Name,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, StoreKeeper storeKeeper)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", storeKeeper.Name, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", storeKeeper.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Inv_StoreKeeper Set Name=@Name,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_StoreKeeper Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_StoreKeeper] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_StoreKeeper] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_StoreKeeper Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}