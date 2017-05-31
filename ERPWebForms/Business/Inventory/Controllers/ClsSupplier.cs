using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsSupplier
    {
        public InvSupplier get(int id)
        {
            string sql = "Select * from Inv_Supplier Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            InvSupplier supplier = new InvSupplier();
            supplier.Name = dt.Rows[0]["Name"].ToString();
            supplier.Address = dt.Rows[0]["Address"].ToString();
            supplier.Email = dt.Rows[0]["Email"].ToString();
            supplier.Phone = dt.Rows[0]["Phone"].ToString();
            supplier.Remarks = dt.Rows[0]["Remarks"].ToString();
            supplier.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            supplier.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            supplier.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            supplier.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return supplier;
        }
        public List<InvSupplier> getList()
        {
            List<InvSupplier> suppliers = new List<InvSupplier>();
            string sql = "Select * from Inv_Supplier ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvSupplier supplier = new InvSupplier();
                supplier.Name = dt.Rows[i]["Name"].ToString();
                supplier.Address = dt.Rows[i]["Address"].ToString();
                supplier.Email = dt.Rows[i]["Email"].ToString();
                supplier.Phone = dt.Rows[i]["Phone"].ToString();
                supplier.Remarks = dt.Rows[i]["Remarks"].ToString();
                supplier.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                supplier.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                supplier.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                supplier.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                suppliers.Add(supplier);
            }
            return suppliers;
        }
        public int insert(InvSupplier supplier) 
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@Name", supplier.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Address", supplier.Address, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Email", supplier.Email, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Phone", supplier.Phone, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@Remarks", supplier.Remarks, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Active", supplier.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", supplier.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_Supplier(Name,Address,Email,Phone,Remarks,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@Address,@Email,@Phone,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, InvSupplier supplier) 
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@Name", supplier.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Address", supplier.Address, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Email", supplier.Email, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Phone", supplier.Phone, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@Remarks", supplier.Remarks, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Active", supplier.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", supplier.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Inv_Supplier Set Name=@Name,Address=@Address,Email=@Email,Phone=@Phone,Remarks=@Remarks,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Supplier Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Supplier] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Supplier] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_Supplier Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}