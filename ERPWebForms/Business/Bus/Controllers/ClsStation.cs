using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Controllers
{
    public class ClsStation
    {
        public Station get(int id)
        {
            string sql = "Select * from Stations Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Station station = new Station();
            station.Name = dt.Rows[0]["Name"].ToString();
            station.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            station.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            station.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            station.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return station;
        }
        public List<Station> getList()
        {
            List<Station> stations = new List<Station>();
            string sql = "Select * from Stations ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Station station = new Station();
                station.Name = dt.Rows[i]["Name"].ToString();
                station.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                station.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                station.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                station.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                stations.Add(station);
            }
            return stations;
        }
        public int insert(Station station)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", station.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Active", station.Active, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", station.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into Stations (Name,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, Station station)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", station.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Active", station.Active, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@ID",id, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", station.OperatorID, SqlDbType.Int, 50);
            string sql = "Update Stations Set Name=@Name,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From Stations Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [Stations] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [Stations] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From Stations Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}