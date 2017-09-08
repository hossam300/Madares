using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPWebForms.Business.Bus.Models;
namespace ERPWebForms.Business.Bus.Controllers
{
    public class ClsBus
    {
        public Buses get(int id)
        {
            string sql = "Select * from Buses Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Buses bus = new Buses();
            bus.BusNumber = dt.Rows[0]["BusNumber"].ToString();
            bus.EndLicenseDate = Convert.ToDateTime(dt.Rows[0]["EndLicenseDate"].ToString());
            bus.NumberOfSeats = Convert.ToInt32(dt.Rows[0]["NumberOfSeats"].ToString());
            bus.BusCondition = dt.Rows[0]["BusCondition"].ToString();
            bus.DriverId = Convert.ToInt32(dt.Rows[0]["DriverId"].ToString());
            bus.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            bus.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            bus.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            bus.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return bus;
        }
        public List<Buses> getList()
        {
            List<Buses> buses = new List<Buses>();
            string sql = "Select * from Buses ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Buses bus = new Buses();
                bus.BusNumber = dt.Rows[i]["BusNumber"].ToString();
                bus.EndLicenseDate = Convert.ToDateTime(dt.Rows[i]["EndLicenseDate"].ToString());
                bus.NumberOfSeats = Convert.ToInt32(dt.Rows[i]["NumberOfSeats"].ToString());
                bus.BusCondition = dt.Rows[i]["BusCondition"].ToString();
                bus.DriverId = Convert.ToInt32(dt.Rows[i]["DriverId"].ToString());
                bus.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                bus.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                bus.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                bus.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                buses.Add(bus);
            }
            return buses;
        }
        public int insert(Buses bus)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@BusNumber", bus.BusNumber, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@EndLicenseDate", bus.EndLicenseDate, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParamter("@NumberOfSeats", bus.NumberOfSeats, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@BusCondition", bus.BusCondition, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@DriverId", bus.DriverId, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@Active", bus.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", bus.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Buses(BusNumber,EndLicenseDate,NumberOfSeats,BusCondition,DriverId,CreationDate,LastModifiedDate,OperatorID,Active) Values (@BusNumber,@EndLicenseDate,@NumberOfSeats,@BusCondition,@DriverId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, Buses bus)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@BusNumber", bus.BusNumber, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@EndLicenseDate", bus.EndLicenseDate, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParamter("@NumberOfSeats", bus.NumberOfSeats, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@BusCondition", bus.BusCondition, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@DriverId", bus.DriverId, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@Active", bus.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@ID", bus.ID, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", bus.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Buses Set BusNumber=@BusNumber,EndLicenseDate=@EndLicenseDate,NumberOfSeats=@NumberOfSeats,BusCondition=@BusCondition,DriverId=@DriverId,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Buses Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Buses] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Buses] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Buses Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}
