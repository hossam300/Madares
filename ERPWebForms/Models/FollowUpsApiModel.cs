using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Models
{
    public class FollowUpsApiModel
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Operator{ get; set; }
        public string Replay { get; set; }
        public int FollowUpID { get; set; }
        public DataTable getlist(int id) {
            string sql = "SELECT * FROM [dbo].[Std_FollowUp_Replays] where FollowUpID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            return dt;
        }
        public int get(int id)
        {
            string sql = "SELECT * FROM [dbo].[Std_FollowUp_Replays] where ID="+id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                CreationDate = DateTime.Parse(dt.Rows[0]["CreationDate"].ToString());
                LastModifiedDate = DateTime.Parse(dt.Rows[0]["LastModifiedDate"].ToString());
                Operator = dt.Rows[0]["Operator"].ToString();
                ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                Replay = dt.Rows[0]["Replay"].ToString();
                FollowUpID = id;
            }
            return id;
        }
        public void save() {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParamter("@Operator", Operator, SqlDbType.NVarChar, 250);
            param[3] = DataAccess.AddParamter("@Replay", Replay, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@FollowUpID", FollowUpID, SqlDbType.Int, 50);
            string sql = "INSERT INTO [dbo].[Std_FollowUp_Replays] ([CreationDate] ,[LastModifiedDate],[Operator],[Replay],[FollowUpID])  VALUES(@LastModifiedDate,@Creationdate,@Operator,@Replay,@FollowUpID)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
        }
    }
}