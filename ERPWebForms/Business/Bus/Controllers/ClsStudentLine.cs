using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Controllers
{
    public class ClsStudentLine
    {
        public StudentLine get(int id)
        {
            string sql = "Select * from StudentLines Where LineId=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            StudentLine studentLine = new StudentLine();
            studentLine.LineId =Convert.ToInt32(dt.Rows[0]["LineId"].ToString());
            studentLine.StudentId = Convert.ToInt32(dt.Rows[0]["StudentId"].ToString());
            studentLine.StationId = Convert.ToInt32(dt.Rows[0]["StationId"].ToString());
            studentLine.Amount =Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
            studentLine.PaymentType = dt.Rows[0]["PaymentType"].ToString();
            studentLine.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            studentLine.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            studentLine.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            studentLine.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return studentLine;
        }
        public DataTable GetStudentLines(int lindId) {
            string sql = "Select * from StudentLines Where LineId=" + lindId.ToString();
           return DataAccess.ExecuteSQLQuery(sql);
        }
        public List<StudentLine> getList()
        {
            List<StudentLine> studentLines = new List<StudentLine>();
            string sql = "Select * from StudentLines ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentLine studentLine = new StudentLine();
                studentLine.LineId = Convert.ToInt32(dt.Rows[i]["LineId"].ToString());
                studentLine.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                studentLine.StationId = Convert.ToInt32(dt.Rows[i]["StationId"].ToString());
                studentLine.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                studentLine.PaymentType = dt.Rows[i]["PaymentType"].ToString();
                studentLine.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                studentLine.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                studentLine.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                studentLine.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                studentLines.Add(studentLine);
            }
            return studentLines;
        }
        public int insert(StudentLine studentLine)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@LineId", studentLine.LineId, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@StudentId", studentLine.StudentId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@StationId", studentLine.StationId, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Amount", studentLine.Amount, SqlDbType.DateTime, 500);
            param[4] = DataAccess.AddParamter("@PaymentType", studentLine.PaymentType, SqlDbType.DateTime, 500);
            param[5] = DataAccess.AddParamter("@Active", studentLine.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", studentLine.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into StudentLines(LineId,StudentId,StationId,Amount,PaymentType,CreationDate,LastModifiedDate,OperatorID,Active) Values (@LineId,@StudentId,@StationId,@Amount,@PaymentType,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int update(int id, StudentLine studentLine)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@LineId", studentLine.LineId, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@StudentId", studentLine.StudentId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@StationId", studentLine.StationId, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Amount", studentLine.Amount, SqlDbType.DateTime, 500);
            param[4] = DataAccess.AddParamter("@PaymentType", studentLine.PaymentType, SqlDbType.DateTime, 500);
            param[5] = DataAccess.AddParamter("@Active", studentLine.Active, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[8] = DataAccess.AddParamter("@OperatorID", studentLine.OperatorID, SqlDbType.Int, 50);
            string sql = "Update StudentLines Set LineId=@LineId,StudentId=@StudentId,StationId=@StationId,Amount=@Amount,PaymentType=@PaymentType," +
                "LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From StudentLines Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [StudentLines] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [StudentLines] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From StudentLines Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}