using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Controllers
{
    public class ClsCustomer
    {
        public InvCustomer get(int id)
        {
            string sql = "Select * from Inv_Customer Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            InvCustomer customer = new InvCustomer();
            customer.Name = dt.Rows[0]["Name"].ToString();
            customer.Type = Convert.ToInt32(dt.Rows[0]["Type"].ToString());
            customer.Address = dt.Rows[0]["Address"].ToString();
            customer.Email = dt.Rows[0]["Email"].ToString();
            customer.Phone = dt.Rows[0]["Phone"].ToString();
            customer.Remarks = dt.Rows[0]["Remarks"].ToString();
            customer.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            customer.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            customer.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            customer.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return customer;
        }
        public List<InvCustomer> getList()
        {
            List<InvCustomer> customers = new List<InvCustomer>();
            string sql = "Select * from Inv_Customer ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvCustomer customer = new InvCustomer();
                customer.Name = dt.Rows[i]["Name"].ToString();
                customer.Type = Convert.ToInt32(dt.Rows[i]["Type"].ToString());
                customer.Address = dt.Rows[i]["Address"].ToString();
                customer.Email = dt.Rows[i]["Email"].ToString();
                customer.Phone = dt.Rows[i]["Phone"].ToString();
                customer.Remarks = dt.Rows[i]["Remarks"].ToString();
                customer.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                customer.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                customer.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                customer.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                customers.Add(customer);
            }
            return customers;
        }
        public int insert(InvCustomer customer)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@Name", customer.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Type", customer.Type, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Address", customer.Address, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Email", customer.Email, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@Phone", customer.Phone, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Remarks", customer.Remarks, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@Active", customer.Active, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@OperatorID", customer.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Inv_Customer(Name,Type,Address,Email,Phone,Remarks,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@Type,@Address,@Email,@Phone,@Remarks,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, InvCustomer customer)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@Name", customer.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Type", customer.Type, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Address", customer.Address, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Email", customer.Email, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@Phone", customer.Phone, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@Remarks", customer.Remarks, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@Active", customer.Active, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@OperatorID", customer.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Inv_Customer Set Name=@Name,Type=@Type,Address=@Address,Email=@Email,Phone=@Phone,Remarks=@Remarks,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Inv_Customer Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Inv_Customer] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Inv_Customer] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Inv_Customer Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}
