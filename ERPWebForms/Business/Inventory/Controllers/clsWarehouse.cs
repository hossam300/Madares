using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class clsWarehouse
    {
        public Warehouse get(int id)
        {
            string sql = "Select * From [Inv_Warehouse] Where ID=" + id;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Warehouse wearhouse = new Warehouse();
            wearhouse.ID = id;
            wearhouse.Name = dt.Rows[0]["Name"].ToString();
            wearhouse.Address = dt.Rows[0]["Address"].ToString();
            wearhouse.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            wearhouse.StoreKeeper = Convert.ToInt32(dt.Rows[0]["StoreKeeper"].ToString());
            wearhouse.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            wearhouse.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            wearhouse.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            sql = "SELECT dbo.Inv_ProductWearhous.ID, dbo.Inv_ProductWearhous.ProductID, dbo.Inv_ProductWearhous.WarehouseID, dbo.Inv_ProductWearhous.Active, dbo.Inv_ProductWearhous.Quantity, dbo.Inv_ProductWearhous.Cost, dbo.Inv_ProductWearhous.Price, dbo.Inv_ProductWearhous.Barcode, dbo.Inv_Warehouse.Name" +
                   " FROM dbo.Inv_ProductWearhous INNER JOIN dbo.Inv_Warehouse ON dbo.Inv_ProductWearhous.WarehouseID = dbo.Inv_Warehouse.ID" +
                 " WHERE (dbo.Inv_ProductWearhous.WearhouseID = " + id + ")";
            DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                ProductWatehouse productWatehouse = new ProductWatehouse();
                productWatehouse.ID = Convert.ToInt32(dt2.Rows[i]["WearhouseID"].ToString());
                productWatehouse.ProductID = Convert.ToInt32(dt2.Rows[i]["ProductID"].ToString());
                productWatehouse.WarehouseID = Convert.ToInt32(dt2.Rows[i]["WarehouseID"].ToString());
                productWatehouse.Active = Convert.ToInt32(dt2.Rows[i]["Active"].ToString());
                productWatehouse.Quantity = Convert.ToInt32(dt2.Rows[i]["Quantity"].ToString());
                productWatehouse.Cost = Convert.ToInt32(dt2.Rows[i]["Cost"].ToString());
                productWatehouse.Price = Convert.ToInt32(dt2.Rows[i]["Price"].ToString());
                productWatehouse.Barcode = dt2.Rows[i]["Barcode"].ToString();
                wearhouse.productWatehouse.Add(productWatehouse);
            }
            return wearhouse;
        }
        public List<Warehouse> getlist()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            string sql = "Select * From [Inv_Warehouse] ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Warehouse wearhouse = new Warehouse();
                wearhouse.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                wearhouse.Name = dt.Rows[i]["Name"].ToString();
                wearhouse.Address = dt.Rows[i]["Address"].ToString();
                wearhouse.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                wearhouse.StoreKeeper = Convert.ToInt32(dt.Rows[i]["StoreKeeper"].ToString());
                wearhouse.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                wearhouse.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                wearhouse.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                warehouses.Add(wearhouse);
            }
            return warehouses;
        }
        public int insert(Warehouse wearhouse)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@Name", wearhouse.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Address", wearhouse.Address, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Active", wearhouse.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@StoreKeeper", wearhouse.StoreKeeper, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@OperatorID", wearhouse.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into [Inv_Warehouse] ([Name],[Address],[StoreKeeper],[Active],[CreationDate],[LastModifiedDate],[OperatorID]) VALUES(@Name,@Address,@StoreKeeper,@Active,@CreationDate,@LastModifiedDate,@OperatorID)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, Warehouse wearhouse)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@Name", wearhouse.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Address", wearhouse.Address, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Active", wearhouse.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@StoreKeeper", wearhouse.StoreKeeper, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@OperatorID", wearhouse.OperatorID, SqlDbType.Int, 50);
            string sql = "Update [Inv_Warehouse] Set Name=@Name,Address=@Address,Active=@Active,StoreKeeper=@StoreKeeper,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Warehouse Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Warehouse] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Warehouse] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From  [Inv_Warehouse] Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}