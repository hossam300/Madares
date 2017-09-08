using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Controllers
{
    public class ClsSittingNumber
    {
        public SittingNumber get(int id)
        {
            string sql = "Select * from SittingNumbers Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            SittingNumber sittingNumber = new SittingNumber();
            sittingNumber.StudentId = Convert.ToInt32(dt.Rows[0]["StudentId"].ToString());
            sittingNumber.Number = dt.Rows[0]["Number"].ToString();
            sittingNumber.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            sittingNumber.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            sittingNumber.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            sittingNumber.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return sittingNumber;
        }
        public List<SittingNumber> getList()
        {
            List<SittingNumber> sittingNumbers = new List<SittingNumber>();
            string sql = "Select * from SittingNumbers ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SittingNumber sittingNumber = new SittingNumber();
                sittingNumber.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                sittingNumber.Number = dt.Rows[i]["Number"].ToString();
                sittingNumber.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                sittingNumber.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                sittingNumber.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                sittingNumber.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                sittingNumbers.Add(sittingNumber);
            }
            return sittingNumbers;
        }
        public void InsertBulk() {
            string sql = "Select * From Std_Student";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = "Select * From SittingNumbers Where StudentId="+ dt.Rows[i]["ID"].ToString();
                DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
                if (dt2.Rows.Count==0)
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param[1] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    sql = "Insert Into SittingNumbers (StudentId,Number,CreationDate,LastModifiedDate,OperatorID,Active)"+
                        " Values (" + dt.Rows[i]["ID"].ToString() + "," + DateTime.Now.ToString("yyyymmdd") + "" + dt.Rows[i]["ID"].ToString() + ",@CreationDate,@LastModifiedDate,1,1)";
                    DataAccess.ExecuteSQLNonQuery(sql,param);
                }
            }
        }
        public int insert(SittingNumber sittingNumber)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@StudentId", sittingNumber.StudentId, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Number", sittingNumber.Number, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Active", sittingNumber.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@OperatorID", sittingNumber.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into SittingNumbers (StudentId,Number,CreationDate,LastModifiedDate,OperatorID,Active) Values (@StudentId,@Number,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, SittingNumber sittingNumber)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@StudentId", sittingNumber.StudentId, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Number", sittingNumber.Number, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@Active", sittingNumber.Active, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@ID", id, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@OperatorID", sittingNumber.OperatorID, SqlDbType.Int, 50);
            string sql = "Update SittingNumbers Set StudentId=@StudentId,Number=@Number,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From SittingNumbers Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [SittingNumbers] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [SittingNumbers] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From SittingNumbers Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}