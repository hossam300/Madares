using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveType
/// </summary>
public class LeaveType:baseObject
{
    string _leaveType;

    public string LeaveTypeName
    {
        get { return _leaveType; }
        set { _leaveType = value; }
    }
    int _balance;

    public int Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    int _deduction;

    public int Deduction
    {
        get { return _deduction; }
        set { _deduction = value; }
    }
    decimal _deductionValue;

    public decimal DeductionValue
    {
        get { return _deductionValue; }
        set { _deductionValue = value; }
    }
	public LeaveType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_LeaveType where LeaveTypeID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _leaveType = dt.Rows[0]["LeaveType"].ToString();
            int.TryParse(dt.Rows[0]["Deduction"].ToString(), out _deduction);
            decimal.TryParse(dt.Rows[0]["DeductionValue"].ToString(), out _deductionValue);
            int.TryParse(dt.Rows[0]["Balance"].ToString(), out _balance);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_LeaveType ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@LeaveType", _leaveType, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Deduction", _deduction, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@DeductionValue", _deductionValue, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@Balance", _balance, SqlDbType.Int, 50);

        string sql = "INSERT INTO [HR_LeaveType] ([LeaveType] ,[CreationDate],[LastModifiedDate],[OperatorID],[Deduction],[DeductionValue],[Balance]) values (@LeaveType,@Creationdate,@LastModifiedDate,@OperatorID,@Deduction,@DeductionValue,@Balance)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(LeaveTypeID)as lastID from HR_LeaveType";
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
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@LeaveType", _leaveType, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Deduction", _deduction, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@DeductionValue", _deductionValue, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@Balance", _balance, SqlDbType.Int, 50);
        string sql = "UPDATE [HR_LeaveType] SET [LeaveType] = @LeaveType,[Deduction]=@Deduction,[DeductionValue]=@DeductionValue,[Balance]=@Balance,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  WHERE LeaveTypeID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}