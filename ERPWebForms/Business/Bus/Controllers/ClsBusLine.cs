using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Controllers
{
    public class ClsBusLine
    {
        public BusLine get(int id)
        {
            string sql = "Select * from BusLines Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            BusLine busLine = new BusLine();
            busLine.Name = dt.Rows[0]["Name"].ToString();
            busLine.StartStationId = Convert.ToInt32(dt.Rows[0]["StartStationId"].ToString());
            busLine.SupervisorId = Convert.ToInt32(dt.Rows[0]["SupervisorId"].ToString());
            sql = "Select * from StationLines Where LineId=" + id.ToString();
            DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
            List<StationLine> stationLines = new List<StationLine>();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                StationLine stationLine = new StationLine();
                stationLine.LineId = Convert.ToInt32(dt2.Rows[i]["LineId"].ToString());
                stationLine.StationId = Convert.ToInt32(dt2.Rows[i]["StationId"].ToString());
                stationLine.Time = dt2.Rows[i]["Time"].ToString();
                stationLine.OrderOnLine = Convert.ToInt32(dt2.Rows[i]["OrderOnLine"].ToString());
                stationLine.Active = Convert.ToInt32(dt2.Rows[i]["Active"].ToString());
                stationLines.Add(stationLine);
            }
            busLine.StationsLines = stationLines;
            busLine.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
            busLine.OperatorID = Convert.ToInt32(dt.Rows[0]["OperatorID"].ToString());
            busLine.CreationDate = Convert.ToDateTime(dt.Rows[0]["CreationDate"].ToString());
            busLine.LastModifiedDate = Convert.ToDateTime(dt.Rows[0]["LastModifiedDate"].ToString());
            return busLine;
        }
        public DataTable GetBusLineStation(int LindID) {
            string sql = "Select ID,StationId,Time,OrderOnLine from StationLines Where LineId=" + LindID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            return dt;
        }
        public List<BusLine> getList()
        {
            List<BusLine> busLines = new List<BusLine>();
            string sql = "Select * from BusLines ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BusLine busLine = new BusLine();
                busLine.Name = dt.Rows[i]["Name"].ToString();
                busLine.StartStationId = Convert.ToInt32(dt.Rows[i]["StartStationId"].ToString());
                busLine.SupervisorId = Convert.ToInt32(dt.Rows[i]["SupervisorId"].ToString());
                busLine.Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString());
                busLine.OperatorID = Convert.ToInt32(dt.Rows[i]["OperatorID"].ToString());
                busLine.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"].ToString());
                busLine.LastModifiedDate = Convert.ToDateTime(dt.Rows[i]["LastModifiedDate"].ToString());
                busLines.Add(busLine);
            }
            return busLines;
        }
        public int insert(BusLine busLine)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@Name", busLine.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@StartStationId", busLine.StartStationId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@SupervisorId", busLine.SupervisorId, SqlDbType.Int, 500);
            param[3] = DataAccess.AddParamter("@Active", busLine.Active, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@OperatorID", busLine.OperatorID, SqlDbType.Int, 50);
            string sql = "Insert Into BusLines(Name,StartStationId,SupervisorId,CreationDate,LastModifiedDate,OperatorID,Active) Values (@Name,@StartStationId,@SupervisorId,@CreationDate,@LastModifiedDate,@OperatorID,1)";
             DataAccess.ExecuteSQLNonQuery(sql, param);
             sql = "select max(id)as lastID from BusLines";
             DataTable dt = DataAccess.ExecuteSQLQuery(sql);
             int res = 0;
             if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
             {
                 int id = int.Parse(dt.Rows[0]["lastID"].ToString());
                 for (int i = 0; i < busLine.StationsLines.Count; i++)
                 {
                     SqlParameter[] param2 = new SqlParameter[8];
                     param2[0] = DataAccess.AddParamter("@LineId", id, SqlDbType.Int, 50);
                     param2[1] = DataAccess.AddParamter("@StationId", busLine.StationsLines[i].StationId, SqlDbType.Int, 50);
                     param2[2] = DataAccess.AddParamter("@Active", busLine.StationsLines[i].Active, SqlDbType.Int, 50);
                     param2[3] = DataAccess.AddParamter("@Time", busLine.StationsLines[i].Time, SqlDbType.NVarChar, 500);
                     param2[4] = DataAccess.AddParamter("@OrderOnLine", busLine.StationsLines[i].OrderOnLine, SqlDbType.Int, 50);
                     param2[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                     param2[6] = DataAccess.AddParamter("@OperatorID", busLine.OperatorID, SqlDbType.Int, 50);
                     param2[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                     sql = "Insert Into StationLines (LineId,StationId,Time,OrderOnLine,CreationDate,LastModifiedDate,OperatorID,Active) " +
                         "Values (@LineId,@StationId,@Time,@OrderOnLine,@CreationDate,@LastModifiedDate,@OperatorID,1)";
                   res=DataAccess.ExecuteSQLNonQuery(sql, param2);
                 }
             }
             
            return res;
        }
        public int update(int id, BusLine busLine)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@Name", busLine.Name, SqlDbType.NVarChar, 500);
            param[1] = DataAccess.AddParamter("@StartStationId", busLine.StartStationId, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@SupervisorId", busLine.SupervisorId, SqlDbType.Int, 500);
            param[3] = DataAccess.AddParamter("@Active", busLine.Active, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@OperatorID", busLine.OperatorID, SqlDbType.Int, 50);
            string sql = "Update BusLines Set Name=@Name,StartStationId=@StartStationId,SupervisorId=@SupervisorId,LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Active=1 Where ID=@ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            sql = "delete from StationLines where LineId = @ID";
            param = new SqlParameter[1];
            param[0] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int res = 0;
            if (busLine.StationsLines != null  && busLine.StationsLines.Count > 0)
            {
                
                for (int i = 0; i < busLine.StationsLines.Count; i++)
                {
                    SqlParameter[] param2 = new SqlParameter[8];
                    param2[0] = DataAccess.AddParamter("@LineId", id, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@StationId", busLine.StationsLines[i].StationId, SqlDbType.Int, 50);
                    param2[2] = DataAccess.AddParamter("@Active", busLine.StationsLines[i].Active, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@Time", busLine.StationsLines[i].Time, SqlDbType.NVarChar, 500);
                    param2[4] = DataAccess.AddParamter("@OrderOnLine", busLine.StationsLines[i].OrderOnLine, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[6] = DataAccess.AddParamter("@OperatorID", busLine.OperatorID, SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
                    sql = "Insert Into StationLines (LineId,StationId,Time,OrderOnLine,CreationDate,LastModifiedDate,OperatorID,Active) " +
                        "Values (@LineId,@StationId,@Time,@OrderOnLine,@CreationDate,@LastModifiedDate,@OperatorID,1)";
                    res = DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return res;
        }
        public int Active(int id)
        {
            string sql = "Select Active From BusLines Where ID=" + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (Convert.ToInt32(dt.Rows[0]["Active"].ToString()) == 1)
                sql = "Update [BusLines] set Active=0 Where ID =" + id.ToString();
            else
                sql = "Update [BusLines] set Active=1 Where ID =" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
        public int delete(int id)
        {
            string sql = "Delete From BusLines Where ID=" + id.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            sql = "Delete From StationLines Where LineId=" + id.ToString();
            res = DataAccess.ExecuteSQLNonQuery(sql);
            sql = "Delete From StudentLines Where LineId=" + id.ToString();
            res = DataAccess.ExecuteSQLNonQuery(sql);
            return res;
        }
    }
}