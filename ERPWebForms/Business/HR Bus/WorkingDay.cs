using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WorkingDays
/// </summary>
public class WorkingDay:baseObject
{
    string _saturday;
    public string Saturday
    {
        get { return _saturday; }
        set { _saturday = value; }
    }
    string _sunday;
    public string Sunday
    {
        get { return _sunday; }
        set { _sunday = value; }
    }
    string _monday;
    public string Monday
    {
        get { return _monday; }
        set { _monday = value; }
    }
    string _tuesday;
    public string Tuesday
    {
        get { return _tuesday; }
        set { _tuesday = value; }
    }
    string _wednesday;
    public string Wednesday
    {
        get { return _wednesday; }
        set { _wednesday = value; }
    }
    string _thursday;
    public string Thursday
    {
        get { return _thursday; }
        set { _thursday = value; }
    }
    string _friday;
    public string Friday
    {
        get { return _friday; }
        set { _friday = value; }
    }
	public WorkingDay()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_WorkingDays where WorkingDayID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            _id = id;
            _saturday = dt.Rows[0]["Saturday"].ToString();
            _sunday = dt.Rows[0]["Sunday"].ToString();
            _monday = dt.Rows[0]["Monday"].ToString();
            _tuesday = dt.Rows[0]["Tuesday"].ToString();
            _wednesday = dt.Rows[0]["Wednesday"].ToString();
            _thursday = dt.Rows[0]["Thursday"].ToString();
            _friday = dt.Rows[0]["Friday"].ToString();
        }
        return id;
          
    }

    public override System.Data.DataTable getList()
    {
        throw new NotImplementedException();
    }

    public override int save()
    {
        throw new NotImplementedException();
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);       
        param[1] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@Saturday", _saturday, SqlDbType.NVarChar, 500);
        param[3] = DataAccess.AddParamter("@Sunday", _sunday, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Monday", _monday, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@Tuesday", _tuesday, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Wednesday", _wednesday, SqlDbType.NVarChar, 500);
        param[7] = DataAccess.AddParamter("@Thursday", _thursday, SqlDbType.NVarChar, 500);
        param[8] = DataAccess.AddParamter("@Friday", _friday, SqlDbType.NVarChar, 500);


        string sql = "UPDATE [HR_WorkingDays] SET [Saturday] = @Saturday,[Sunday] = @Sunday ,[Monday] = @Monday ,[Tuesday] = @Tuesday ,[Wednesday] = @Wednesday ,[Thursday] = @Thursday ,[Friday] = @Friday ,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  ";
        DataAccess.ExecuteSQLNonQuery(sql, param);
       
        return 1;
    }
}