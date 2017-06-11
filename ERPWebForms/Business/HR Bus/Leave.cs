using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Leaves
/// </summary>
public class Leave : baseObject
{
    int _empID;

    public int EmpID
    {
        get { return _empID; }
        set { _empID = value; }
    }
    int _leavetypeID;

    public int LeaveTypeID
    {
        get { return _leavetypeID; }
        set { _leavetypeID = value; }
    }
    DateTime _fromdate;

    public DateTime FromDate
    {
        get { return _fromdate; }
        set { _fromdate = value; }
    }

    DateTime _toDate;

    public DateTime ToDate
    {
        get { return _toDate; }
        set { _toDate = value; }
    }
    string _comment;

    public string Comment
    {
        get { return _comment; }
        set { _comment = value; }
    }
    int _numberOfDays;
    public int NumberOfDays
    {
        get { return _numberOfDays; }
        set { _numberOfDays = value; }
    }
	public Leave()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_Leaves where LeaveID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            int.TryParse(dt.Rows[0]["EmpID"].ToString(), out _empID);
            int.TryParse(dt.Rows[0]["LeaveTypeID"].ToString(), out _leavetypeID);

            DateTime.TryParse(dt.Rows[0]["FromDate"].ToString(), out  _fromdate);
            DateTime.TryParse(dt.Rows[0]["ToDate"].ToString(), out  _toDate);
            _comment = dt.Rows[0]["Comment"].ToString();
            int.TryParse(dt.Rows[0]["NoOfDays"].ToString(), out _numberOfDays);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "SELECT HR_Leaves.LeaveID, HR_Employees.EmpName, HR_LeaveType.LeaveType, HR_Leaves.FromDate, HR_Leaves.ToDate, HR_Leaves.Comment, DATEDIFF(day, HR_Leaves.FromDate, HR_Leaves.ToDate)   AS Days FROM  HR_Leaves INNER JOIN   HR_LeaveType ON HR_Leaves.LeaveTypeID = HR_LeaveType.LeaveTypeID INNER JOIN  HR_Employees ON HR_Leaves.EmpID = HR_Employees.EmpID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@LeaveTypeID", _leavetypeID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@FromDate", _fromdate, SqlDbType.DateTime, 50);
        param[6] = DataAccess.AddParamter("@ToDate", _toDate, SqlDbType.DateTime, 50);
        param[7] = DataAccess.AddParamter("@Comment", _comment, SqlDbType.NVarChar, 500);
        param[8] = DataAccess.AddParamter("@NoOfDays", _numberOfDays, SqlDbType.Int, 50);
        string sql = "INSERT INTO [dbo].[HR_Leaves] ([EmpID] ,[LeaveTypeID],[FromDate],[ToDate],[Comment],[CreationDate],[LastModifiedDate],[OperatorID],[NoOfDays]) values (@EmpID,@LeaveTypeID,@FromDate,@ToDate,@Comment,@Creationdate,@LastModifiedDate,@OperatorID,@NoOfDays)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(LeaveID)as lastID from HR_Leaves";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());

            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@LeaveTypeID", _leavetypeID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@FromDate", _fromdate, SqlDbType.DateTime, 50);
        param[6] = DataAccess.AddParamter("@ToDate", _toDate, SqlDbType.DateTime, 50);
        param[7] = DataAccess.AddParamter("@Comment", _comment, SqlDbType.NVarChar, 500);
        param[8] = DataAccess.AddParamter("@NoOfDays", _numberOfDays, SqlDbType.Int, 50);
        string sql = "UPDATE [dbo].[HR_Leaves] SET [EmpID] = @EmpID,[LeaveTypeID] = @LeaveTypeID ,[FromDate] = @FromDate ,[ToDate] = @ToDate ,[Comment] = @Comment,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID,[NoOfDays]=@NoOfDays  WHERE LeaveID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
    public bool overBalance(int EmpID,int leaveType) {
        string sql = "select count(*) as leavesCount from HR_Leaves where EmpID=" + EmpID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        sql = "select Balance as Balance from HR_LeaveType where LeaveTypeID=" + leaveType.ToString();
        DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
        if (Convert.ToInt32(dt.Rows[0]["leavesCount"].ToString()) >= Convert.ToInt32(dt2.Rows[0]["Balance"].ToString()))
        {
            return true;
        }
        return false;
    }
}