using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Controllers
{
    public class Clsfloor
    {
        public floor get(int id)
        {
            string sql = "Select * from floors Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            floor floor = new floor();
            floor.Name = dt.Rows[0]["Name"].ToString();
            floor.SupervisorId = Convert.ToInt32(dt.Rows[0]["SupervisorId"].ToString());
            floor.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            floor.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            floor.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            floor.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return floor;
        }
        public List<floor> getList()
        {
            List<floor> floors = new List<floor>();
            string sql = "Select * from floors ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                floor floor = new floor();
                floor.Name = dt.Rows[i]["Name"].ToString();
                floor.SupervisorId = Convert.ToInt32(dt.Rows[i]["SupervisorId"].ToString());
                floor.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                floor.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                floor.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                floor.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                floors.Add(floor);
            }
            return floors;
        }
        public int insert(floor floor)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@Name", floor.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@SupervisorId", floor.SupervisorId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Active", floor.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@OperatorID", floor.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into floors (Name,SupervisorId,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@SupervisorId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, floor floor)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@Name", floor.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@SupervisorId", floor.SupervisorId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Active", floor.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@OperatorID", floor.OperatorID, SqlDbType.Int, 50);
            string sql = "Update floors Set Name=@Name,SupervisorId=@SupervisorId,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From floors Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [floors] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [floors] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From floors Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}