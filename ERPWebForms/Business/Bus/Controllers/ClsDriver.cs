using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Controllers
{
    public class ClsDriver
    {
        public Driver get(int id)
        {
            string sql = "Select * from Drivers Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Driver driver = new Driver();
            driver.Name = dt.Rows[0]["Name"].ToString();
            driver.Phone = dt.Rows[0]["Phone"].ToString();
            driver.LicenseNumber = dt.Rows[0]["LicenseNumber"].ToString();
            driver.LicenseEndDate = Convert.ToDateTime(dt.Rows[0]["LicenseEndDate"].ToString());
            driver.DateHiring = Convert.ToDateTime(dt.Rows[0]["DateHiring"].ToString());
            driver.EndHiring = Convert.ToDateTime(dt.Rows[0]["EndHiring"].ToString());
            driver.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            driver.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            driver.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            driver.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return driver;
        }
        public List<Driver> getList()
        {
            List<Driver> drivers = new List<Driver>();
            string sql = "Select * from Drivers ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Driver driver = new Driver();
                driver.Name = dt.Rows[i]["Name"].ToString();
                driver.Phone = dt.Rows[i]["Phone"].ToString();
                driver.LicenseNumber = dt.Rows[i]["LicenseNumber"].ToString();
                driver.LicenseEndDate = Convert.ToDateTime(dt.Rows[i]["LicenseEndDate"].ToString());
                driver.DateHiring = Convert.ToDateTime(dt.Rows[i]["DateHiring"].ToString());
                driver.EndHiring = Convert.ToDateTime(dt.Rows[i]["EndHiring"].ToString());
                driver.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                driver.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                driver.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                driver.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                drivers.Add(driver);
            }
            return drivers;
        }
        public int insert(Driver driver)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@Name", driver.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Phone", driver.Phone, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@LicenseNumber", driver.LicenseNumber, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@LicenseEndDate", driver.LicenseEndDate, SqlDbType.DateTime, 500);
            param[4] = DataAccess.AddParamter("@DateHiring", driver.DateHiring, SqlDbType.DateTime, 500);
            param[5] = DataAccess.AddParamter("@EndHiring", driver.EndHiring, SqlDbType.DateTime, 500);
            param[6] = DataAccess.AddParamter("@Active", driver.Active, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@OperatorID", driver.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Drivers(Name,Phone,LicenseNumber,LicenseEndDate,DateHiring,EndHiring,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@Phone,@LicenseNumber,@LicenseEndDate,@DateHiring,@EndHiring,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, Driver driver)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@Name", driver.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Phone", driver.Phone, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@LicenseNumber", driver.LicenseNumber, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@LicenseEndDate", driver.LicenseEndDate, SqlDbType.DateTime, 500);
            param[4] = DataAccess.AddParamter("@DateHiring", driver.DateHiring, SqlDbType.DateTime, 500);
            param[5] = DataAccess.AddParamter("@EndHiring", driver.EndHiring, SqlDbType.DateTime, 500);
            param[6] = DataAccess.AddParamter("@Active", driver.Active, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[9] = DataAccess.AddParamter("@OperatorID", driver.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Drivers Set Name=@Name,Phone=@Phone,LicenseNumber=@LicenseNumber,LicenseEndDate=@LicenseEndDate," +
                "DateHiring=@DateHiring,EndHiring=@EndHiring,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Drivers Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Drivers] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Drivers] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Drivers Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}