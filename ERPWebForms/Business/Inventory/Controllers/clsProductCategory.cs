using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class clsProductCategory
    {
        public ProductCategory get(int id)
        {
            string sql = "Select * From Inv_ProductCatrgory Where Active=1 And  ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            ProductCategory productCategory = new ProductCategory();
            productCategory.ID = id;
            productCategory.Name = dt.Rows[0]["Name"].ToString();
            productCategory.Description = dt.Rows[0]["Description"].ToString();
            productCategory.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            productCategory.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            productCategory.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            return productCategory;
        }
        public List<ProductCategory> getList()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            string sql = "Select  ID, Name, Description, CreationDate, LastModifiedDate, OperatorID, Active From Inv_ProductCatrgory Where Active=1";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                productCategory.Name = dt.Rows[i]["Name"].ToString();
                productCategory.Description = dt.Rows[i]["Description"].ToString();
                productCategory.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                productCategory.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                productCategory.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                productCategories.Add(productCategory);
            }
            return productCategories;
        }
        public int insert(ProductCategory productCategory)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", productCategory.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Description", productCategory.Description, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", productCategory.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_ProductCatrgory(Name,Description,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@Description,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, ProductCategory productCategory)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", productCategory.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Description", productCategory.Description, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", productCategory.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Inv_ProductCatrgory Set Name=@Name,Description=@Description,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_ProductCatrgory Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_ProductCatrgory] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_ProductCatrgory] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_ProductCatrgory Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}