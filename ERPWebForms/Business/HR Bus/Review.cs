using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reviews
/// </summary>
public class Review:baseObject
{
    int _empID;
    public int EmpID {
        get { return _empID; }
        set { _empID = value; }
    }
    int _supervisorID;
    public int SupervisorID
    {
        get { return _supervisorID; }
        set { _supervisorID = value; }
    }
    DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    DateTime _endTime;
    public DateTime EndTime
    {
        get { return _endTime; }
        set { _endTime = value; }
    }
    DateTime _dueDate;
    public DateTime DueDate
    {
        get { return _dueDate; }
        set { _dueDate = value; }
    }
    int _status;
    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }
    decimal _review;
    public decimal Reviews
    {
        get { return _review; }
        set { _review = value; }
    }
    DataTable _reviewKPIS;

    public DataTable ReviewKPIS
    {
        get { return _reviewKPIS; }
        set { _reviewKPIS = value; }
    }
	public Review()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_Review where ReviewID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            int.TryParse(dt.Rows[0]["EmpID"].ToString(), out _empID);
            int.TryParse(dt.Rows[0]["SupervisorID"].ToString(), out _supervisorID);
            DateTime.TryParse(dt.Rows[0]["StartDate"].ToString(), out _startDate);
            DateTime.TryParse(dt.Rows[0]["EndDate"].ToString(), out _endTime);
            DateTime.TryParse(dt.Rows[0]["DueDate"].ToString(), out _dueDate);
            int.TryParse(dt.Rows[0]["Status"].ToString(), out _status);
            decimal.TryParse(dt.Rows[0]["Review"].ToString(), out _review);
            sql = "select [ID] ,[KPIID] as KPI,[Rate] from HR_Reviwes_KPIS where ReviewID = " + id.ToString();
            _reviewKPIS = DataAccess.ExecuteSQLQuery(sql);
            return id;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "SELECT HR_Review.ReviewID, HR_Employees.EmpName, Supervisor.EmpName AS Supervisor, HR_Review.StartDate, HR_Review.EndDate, HR_Review.DueDate, HR_Review.Status FROM HR_Review INNER JOIN HR_Employees ON HR_Review.EmpID = HR_Employees.EmpID INNER JOIN HR_Employees AS Supervisor ON HR_Review.SupervisorID = Supervisor.EmpID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@SupervisorID", _supervisorID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@StartDate", _startDate, SqlDbType.DateTime, 50);
        param[6] = DataAccess.AddParamter("@EndDate", _endTime, SqlDbType.DateTime, 50);
        param[7] = DataAccess.AddParamter("@DueDate", _dueDate, SqlDbType.DateTime, 50);
        param[8] = DataAccess.AddParamter("@Status", _status, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@Review", _review, SqlDbType.Decimal, 50);

        string sql = "insert into HR_Review( [CreationDate],[LastModifiedDate],[OperatorID],[EmpID],[SupervisorID],[StartDate],[EndDate],[DueDate],[Status],[Review]) values (@Creationdate,@LastModifiedDate,@OperatorID,@EmpID,@SupervisorID,@StartDate,@EndDate,@DueDate,@Status,@Review)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        sql = "select max(ReviewID) as lastID from HR_Review";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[6];
            if (_reviewKPIS != null && _reviewKPIS.Rows != null && _reviewKPIS.Rows.Count > 0)
            {
                for (int i = 0; i < _reviewKPIS.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@KPIID", _reviewKPIS.Rows[i]["KPI"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@ReviewID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Rate", _reviewKPIS.Rows[i]["Rate"], SqlDbType.Int, 50);

                    sql = "insert into HR_Reviwes_KPIS (CreationDate,LastModifiedDate,OperatorID,KPIID,Rate,ReviewID) values(@CreationDate,@LastModifiedDate,@OperatorID,@KPIID,@Rate,@ReviewID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@SupervisorID", _supervisorID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@StartDate", _startDate, SqlDbType.DateTime, 50);
        param[6] = DataAccess.AddParamter("@EndDate", _endTime, SqlDbType.DateTime, 50);
        param[7] = DataAccess.AddParamter("@DueDate", _dueDate, SqlDbType.DateTime, 50);
        param[8] = DataAccess.AddParamter("@Status", _status, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@Review", _review, SqlDbType.Decimal, 50);
        string sql = "Update  HR_Review Set [LastModifiedDate]=@LastModifiedDate,[OperatorID]=@OperatorID,[EmpID]=@EmpID,[SupervisorID]=@SupervisorID,[StartDate]=@StartDate,[EndDate]=@EndDate,[DueDate]=@DueDate,[Status]=@Status,[Review]=@Review Where ReviewID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        sql = "delete from HR_Reviwes_KPIS where PayGradeID = @ID";
        param = new SqlParameter[1];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        DataAccess.ExecuteSQLNonQuery(sql, param);
        SqlParameter[] param2 = new SqlParameter[10];
        if (_reviewKPIS != null && _reviewKPIS.Rows != null && _reviewKPIS.Rows.Count > 0)
        {
            for (int i = 0; i < _reviewKPIS.Rows.Count; i++)
            {
                param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                param2[3] = DataAccess.AddParamter("@KPIID", _reviewKPIS.Rows[i]["KPI"], SqlDbType.Int, 50);
                param2[4] = DataAccess.AddParamter("@ReviewID", _id, SqlDbType.Int, 50);
                param2[5] = DataAccess.AddParamter("@Rate", _reviewKPIS.Rows[i]["Rate"], SqlDbType.Int, 50);

                sql = "insert into HR_Reviwes_KPIS (CreationDate,LastModifiedDate,OperatorID,KPIID,Rate,ReviewID) values(@CreationDate,@LastModifiedDate,@OperatorID,@KPIID,@Rate,@ReviewID)";
                DataAccess.ExecuteSQLNonQuery(sql, param2);
            }
        }
        return _id;
    }
}