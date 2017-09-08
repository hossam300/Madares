using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Controllers
{
    public class Clsboard
    {
        public board get(int id)
        {
            string sql = "Select * from boards Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            sql = "Select From StudentBords Where BordId=" + id.ToString();
            DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
            board board = new board();
            board.Name = dt.Rows[0]["Name"].ToString();
            board.ClassId = Convert.ToInt32(dt.Rows[0]["ClassId"].ToString());
            board.StudentNum = Convert.ToInt32(dt.Rows[0]["StudentNum"].ToString());
            board.FloorId = Convert.ToInt32(dt.Rows[0]["FloorId"].ToString());
            board.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            board.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            board.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            board.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            List<StudentBord> studentBords = new List<StudentBord>();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                StudentBord studentBord = new StudentBord();
                studentBord.BordId = id;
                studentBord.StudentId = Convert.ToInt32(dt2.Rows[i]["StudentId"].ToString());
                studentBords.Add(studentBord);
            }
            board.StudentBords = studentBords;
            return board;
        }
        public List<board> getList()
        {
            List<board> boards = new List<board>();
            string sql = "Select * from boards ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                board board = new board();
                board.Name = dt.Rows[i]["Name"].ToString();
                board.ClassId = Convert.ToInt32(dt.Rows[i]["ClassId"].ToString());
                board.StudentNum = Convert.ToInt32(dt.Rows[i]["StudentNum"].ToString());
                board.FloorId = Convert.ToInt32(dt.Rows[i]["FloorId"].ToString());
                board.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                board.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                board.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                board.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                boards.Add(board);
            }
            return boards;
        }
        public int insert(board board)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = DataAccess.AddParamter("@Name", board.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@ClassId", board.ClassId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@StudentNum", board.StudentNum, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@FloorId", board.FloorId, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Active", board.Active, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@OperatorID", board.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into boards (Name,ClassId,StudentNum,FloorId,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@ClassId,@StudentNum,@FloorId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            sql = "select max(id)as lastID from boards";
             DataTable dt = DataAccess.ExecuteSQLQuery(sql);
             int res = 0;
             sql = "select Top(" + board.StudentNum + ") [ID] as StudentId From [dbo].[Std_Student] Where [StudClassID]=" + board.ClassId;
             DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
             if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
             {
                 int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                 for (int i = 0; i < dt2.Rows.Count; i++)
                 {
                     SqlParameter[] param2 = new SqlParameter[6];
                     param2[0] = DataAccess.AddParamter("@BordId", id, SqlDbType.Int, 50);
                     param2[1] = DataAccess.AddParamter("@StudentId", dt2.Rows[i]["StudentId"], SqlDbType.Int, 50);
                     param2[2] = DataAccess.AddParamter("@Active", 1, SqlDbType.Int, 50);
                     param2[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                     param2[4] = DataAccess.AddParamter("@OperatorID", board.OperatorID, SqlDbType.Int, 50);
                     param2[5] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                     sql = "Insert Into StudentBords (BordId,StudentId,CreationDate,LastModifiedDate,OperatorID,Active) " +
                         "Values (@BordId,@StudentId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
                     res = DataAccess.ExecuteSQLNonQuery(sql, param2);
                 }
             }
            return res;
        }
        public int update(int id, board board)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = DataAccess.AddParamter("@Name", board.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@ClassId", board.ClassId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@StudentNum", board.StudentNum, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@FloorId", board.FloorId, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Active", board.Active, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@ID",id, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@OperatorID", board.OperatorID, SqlDbType.Int, 50);
            string sql = "Update boards Set Name=@Name,ClassId=@ClassId,StudentNum=@StudentNum,FloorId=@FloorId,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            sql = "delete from StudentBords where BordId = @ID";
            param = new SqlParameter[1];
            param[0] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int res = 0;
            if (board.StudentBords != null && board.StudentBords.Count > 0)
            {
                for (int i = 0; i < board.StudentBords.Count; i++)
                {
                    SqlParameter[] param2 = new SqlParameter[6];
                    param2[0] = DataAccess.AddParamter("@BordId", id, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@StudentId", board.StudentBords[i].StudentId, SqlDbType.Int, 50);
                    param2[2] = DataAccess.AddParamter("@Active", board.StudentBords[i].Active, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[4] = DataAccess.AddParamter("@OperatorID", board.OperatorID, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                    sql = "Insert Into StudentBords (BordId,StudentId,CreationDate,LastModifiedDate,OperatorID,Active) " +
                        "Values (@BordId,@StudentId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
                    res = DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From boards Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [boards] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [boards] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From boards Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            sql = "Delete From StudentBords Where BordId=" + id.ToString();
             res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}