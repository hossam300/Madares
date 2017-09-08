using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Controllers
{
    public class Clssupervisor
    {
        public supervisor get(int id)
        {
            string sql = "Select * from supervisors Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            supervisor supervisor = new supervisor();
            supervisor.Name = dt.Rows[0]["Name"].ToString();
            supervisor.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            supervisor.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            supervisor.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            supervisor.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return supervisor;
        }
        public List<supervisor> getList()
        {
            List<supervisor> supervisors = new List<supervisor>();
            string sql = "Select * from supervisors ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                supervisor supervisor = new supervisor();
                supervisor.Name = dt.Rows[i]["Name"].ToString();
                supervisor.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                supervisor.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                supervisor.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                supervisor.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                supervisors.Add(supervisor);
            }
            return supervisors;
        }
        public int insert(supervisor supervisor)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", supervisor.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Active", supervisor.Active, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", supervisor.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into supervisors (Name,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, supervisor supervisor)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@Name", supervisor.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@Active", supervisor.Active, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@ID", id, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@OperatorID", supervisor.OperatorID, SqlDbType.Int, 50);
            string sql = "Update supervisors Set Name=@Name,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From supervisors Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [supervisors] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [supervisors] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From supervisors Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}