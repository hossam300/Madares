using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class clsProduct
    {
        public InvProduct get(int id)
        {
            string sql = "Select * From Inv_Products Where ID=" + id;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            InvProduct product = new InvProduct();
            product.ID = id;
            product.Name = dt.Rows[0]["Name"].ToString();
            product.SerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            product.StockAmount = Convert.ToInt32(dt.Rows[0]["StockAmount"].ToString());
            product.Cost = Convert.ToDouble(dt.Rows[0]["Cost"].ToString());
            product.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
            product.Barcode = dt.Rows[0]["Barcode"].ToString(); ;
            product.Category = Convert.ToInt32(dt.Rows[0]["Category"].ToString());
            product.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            product.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            product.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            product.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            sql = "SELECT dbo.Inv_ProductWearhous.ID, dbo.Inv_ProductWearhous.ProductID, dbo.Inv_ProductWearhous.WarehouseID, dbo.Inv_ProductWearhous.Active, dbo.Inv_ProductWearhous.Quantity, dbo.Inv_ProductWearhous.Cost, dbo.Inv_ProductWearhous.Price, dbo.Inv_ProductWearhous.Barcode, dbo.Inv_Warehouse.Name" +
                   " FROM dbo.Inv_ProductWearhous INNER JOIN dbo.Inv_Warehouse ON dbo.Inv_ProductWearhous.WarehouseID = dbo.Inv_Warehouse.ID" +
                " WHERE (dbo.Inv_ProductWearhous.ProductID = " + id + ")";
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
                product.productWatehouse.Add(productWatehouse);
            }
            return product;
        }
 
        public List<InvProduct> getList()
        {
            List<InvProduct> products = new List<InvProduct>();
            string sql = "Select * From Inv_Products";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvProduct product = new InvProduct();
                product.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                product.Name = dt.Rows[0]["Name"].ToString();
                product.SerialNumber = dt.Rows[0]["SerialNumber"].ToString();
                product.StockAmount = Convert.ToInt32(dt.Rows[0]["StockAmount"].ToString());
                product.Cost = Convert.ToDouble(dt.Rows[0]["Cost"].ToString());
                product.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
                product.Barcode = dt.Rows[0]["Barcode"].ToString(); ;
                product.Category = Convert.ToInt32(dt.Rows[0]["Category"].ToString());
                product.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
                product.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
                product.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
                product.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
                products.Add(product);
            }
            return products;
        }
        public int insert(InvProduct product)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = DataAccess.AddParamter("@Name", product.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@SerialNumber", product.SerialNumber, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@StockAmount", product.StockAmount, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Cost", product.Cost, SqlDbType.Float, 50);
            param[4] = DataAccess.AddParamter("@Price", product.Price, SqlDbType.Float, 50);
            param[5] = DataAccess.AddParamter("@Barcode", product.Barcode, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@Category", product.Category, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@Active", product.Active, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[10] = DataAccess.AddParamter("@OperatorID", product.OperatorID, SqlDbType.Int, 50);
            param[11] = DataAccess.AddParamter("@LowQuantity", product.LowQuantity, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_Products(Name,SerialNumber,StockAmount,Cost,Price,Barcode,Category,Active,CreationDate,LastModifiedDate,OperatorID,LowQuantity) Values (@Name,@SerialNumber,@StockAmount,@Cost,@Price,@Barcode,@Category,@Active,@CreationDate,@LastModifiedDate,@OperatorID,@LowQuantity)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                sql = "select max(id)as lastID from Inv_Products";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                    for (int i = 0; i < product.productWatehouse.Count; i++)
                    {
                        SqlParameter[] param2 = new SqlParameter[10];
                        param2[0] = DataAccess.AddParamter("@ProductID", id, SqlDbType.Int, 50);
                        param2[1] = DataAccess.AddParamter("@WarehouseID", product.productWatehouse[i].WarehouseID, SqlDbType.Int, 50);
                        param2[2] = DataAccess.AddParamter("@Active", product.productWatehouse[i].Active, SqlDbType.Int, 50);
                        param2[3] = DataAccess.AddParamter("@Quantity", product.productWatehouse[i].Quantity, SqlDbType.Int, 50);
                        param2[4] = DataAccess.AddParamter("@Cost", product.productWatehouse[i].Cost, SqlDbType.Float, 50);
                        param2[5] = DataAccess.AddParamter("@Price", product.productWatehouse[i].Price, SqlDbType.Float, 50);
                        param2[6] = DataAccess.AddParamter("@Barcode", product.productWatehouse[i].Barcode, SqlDbType.NVarChar, 500);
                        param2[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                        param2[8] = DataAccess.AddParamter("@OperatorID", product.OperatorID, SqlDbType.Int, 50);
                        param2[9] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                        sql = "Insert Into Inv_ProductWearhous (ProductID,WarehouseID,Active,Quantity,Cost,Price,Barcode,CreationDate,LastModifiedDate,OperatorID) Values (@ProductID,@WarehouseID,@Active,@Quantity,@Cost,@Price,@Barcode,@CreationDate,@LastModifiedDate,@OperatorID)";
                        DataAccess.ExecuteSQLNonQuery(sql, param2);
                    }
                }
            }
            return res;
        }
        public int update(int id, InvProduct product)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = DataAccess.AddParamter("@Name", product.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@SerialNumber", product.SerialNumber, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@StockAmount", product.StockAmount, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Cost", product.Cost, SqlDbType.Float, 50);
            param[4] = DataAccess.AddParamter("@Price", product.Price, SqlDbType.Float, 50);
            param[5] = DataAccess.AddParamter("@Barcode", product.Barcode, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@Category", product.Category, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@Active", product.Active, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[9] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[10] = DataAccess.AddParamter("@OperatorID", product.OperatorID, SqlDbType.Int, 50);
            param[11] = DataAccess.AddParamter("@LowQuantity", product.LowQuantity, SqlDbType.Int, 50);
            string sql = "Update Inv_Products Set Name=@Name,SerialNumber=@SerialNumber,StockAmount=@StockAmount,Cost=@Cost,Price=@Price,Barcode=@Barcode,Category=@Category,Active=@Active,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,LowQuantity=@LowQuantity Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                sql = "Delete From Inv_ProductWearhous Where ProductID=" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                // int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                for (int i = 0; i < product.productWatehouse.Count; i++)
                {
                    SqlParameter[] param2 = new SqlParameter[10];
                    param2[0] = DataAccess.AddParamter("@ProductID", id, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@WarehouseID", product.productWatehouse[i].WarehouseID, SqlDbType.Int, 50);
                    param2[2] = DataAccess.AddParamter("@Active", product.productWatehouse[i].Active, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@Quantity", product.productWatehouse[i].Quantity, SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@Cost", product.productWatehouse[i].Cost, SqlDbType.Float, 50);
                    param2[5] = DataAccess.AddParamter("@Price", product.productWatehouse[i].Price, SqlDbType.Float, 50);
                    param2[6] = DataAccess.AddParamter("@Barcode", product.productWatehouse[i].Barcode, SqlDbType.NVarChar, 500);
                    param2[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[8] = DataAccess.AddParamter("@OperatorID", product.OperatorID, SqlDbType.Int, 50);
                    param2[9] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                    sql = "Insert Into Inv_ProductWearhous (ProductID,WarehouseID,Active,Quantity,Cost,Price,Barcode,CreationDate,LastModifiedDate,OperatorID) Values (@ProductID,@WarehouseID,@Active,@Quantity,@Cost,@Price,@Barcode,@CreationDate,@LastModifiedDate,@OperatorID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Products Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Products] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Products] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From  [Inv_Products] Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}