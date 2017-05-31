using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeSheet
/// </summary>
public class TimeSheet:baseObject
{
    string _month;
    public string Month{
         get { return _month; }
        set { _month = value; }
    }
    string _year;
    public string Year{
         get { return _year; }
        set { _year = value; }
    }
      DataTable _timeSheet;
    public DataTable TimeSheets
    {
        get { return _timeSheet; }
        set { _timeSheet = value; }
    }
	public TimeSheet()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_TimeSheet where TimeSheetID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _month = dt.Rows[0]["Month"].ToString();
            _year = dt.Rows[0]["Year"].ToString();
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
          
            sql = "select * from HR_EmpTimeSheet where TimeSheetID = " + id.ToString();
            _timeSheet = DataAccess.ExecuteSQLQuery(sql);
            return 1;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_TimeSheet";

        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Month", _month, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@Year", _year, SqlDbType.NVarChar, 200);
        

        string sql = "insert into HR_TimeSheet(CreationDate,LastModifiedDate,OperatorID,Month,Year) values (@Creationdate,@LastModifiedDate,@OperatorID,@Month,@Year)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(TimeSheetID)as lastID from HR_TimeSheet";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[8];
            if (_timeSheet != null && _timeSheet.Rows != null && _timeSheet.Rows.Count > 0)
            {
                for (int i = 0; i < _timeSheet.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@EmpID", _timeSheet.Rows[i]["EmpID"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@TimeSheetID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Date", _timeSheet.Rows[i]["Date"], SqlDbType.NVarChar, 500);
                    param2[6] = DataAccess.AddParamter("@AttendTime", _timeSheet.Rows[i]["AttendTime"], SqlDbType.NVarChar, 500);
                    param2[7] = DataAccess.AddParamter("@LeaveTime", _timeSheet.Rows[i]["LeaveTime"], SqlDbType.NVarChar, 500);

                    sql = "insert into HR_EmpTimeSheet (CreationDate,LastModifiedDate,OperatorID,EmpID,Date,AttendTime,LeaveTime,TimeSheetID) values(@CreationDate,@LastModifiedDate,@OperatorID,@EmpID,@Date,@AttendTime,@LeaveTime,@TimeSheetID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
      SqlParameter[] param = new SqlParameter[5];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID",_id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Month", _month, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@Year", _year, SqlDbType.NVarChar, 200);

        string sql = "Upadate HR_TimeSheet(LastModifiedDate = @LastModifiedDate,OperatorID =@OperatorID ,Month =@Month,Cost =@Year where TimeSheetID =@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        //delete the product price items and insert them again
        sql = "delete from HR_EmpTimeSheet where TimeSheetID = @ID";
        param = new SqlParameter[1];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        DataAccess.ExecuteSQLNonQuery(sql, param);
        SqlParameter[] param2 = new SqlParameter[8];
        if (_timeSheet != null && _timeSheet.Rows != null && _timeSheet.Rows.Count > 0)
        {
            for (int i = 0; i < _timeSheet.Rows.Count; i++)
            {
                param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@EmpID", _timeSheet.Rows[i]["EmpID"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@TimeSheetID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Date", _timeSheet.Rows[i]["Date"], SqlDbType.NVarChar, 500);
                    param2[6] = DataAccess.AddParamter("@AttendTime", _timeSheet.Rows[i]["AttendTime"], SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@LeaveTime", _timeSheet.Rows[i]["LeaveTime"], SqlDbType.NVarChar, 500);

                sql = "insert into HR_EmpTimeSheet (CreationDate,LastModifiedDate,OperatorID,EmpID,Date,AttendTime,LeaveTime,TimeSheetID) values(@CreationDate,@LastModifiedDate,@OperatorID,@EmpID,@Date,@AttendTime,@LeaveTime,@TimeSheetID)";
                DataAccess.ExecuteSQLNonQuery(sql, param2);
            }
        }

        return _id;
    }
    
}