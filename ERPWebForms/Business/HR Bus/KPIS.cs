using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KPIS
/// </summary>
public class KPIS:baseObject
{
    public int _jobTitleID;
    public int JobTitleID
    {
        get { return _jobTitleID; }
        set { _jobTitleID = value; }
    }
    public string _keyPerformanceIndicator;
    public string KeyPerformanceIndicator
    {
        get { return _keyPerformanceIndicator; }
        set { _keyPerformanceIndicator = value; }
    }
    public int _minimumRating;
    public int MinimumRating
    {
        get { return _minimumRating; }
        set { _minimumRating = value; }
    }
    public int _maximumRating;
    public int MaximumRating
    {
        get { return _maximumRating; }
        set { _maximumRating = value; }
    }
    public int _defaultScale;
    public int DefaultScale
    {
        get { return _defaultScale; }
        set { _defaultScale = value; }
    }
	public KPIS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_Kpis where KpiID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["JobTitleID"].ToString(), out _jobTitleID);
            _keyPerformanceIndicator = dt.Rows[0]["KeyPerformanceIndicator"].ToString();
            _id = id;
            int.TryParse(dt.Rows[0]["MinimumRating"].ToString(), out _minimumRating);
            int.TryParse(dt.Rows[0]["MaximumRating"].ToString(), out _maximumRating);
            int.TryParse(dt.Rows[0]["DefaultScale"].ToString(), out _defaultScale);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "SELECT HR_Kpis.KpiID, HR_JobTitle.JobTitle, HR_Kpis.KeyPerformanceIndicator, HR_Kpis.MinimumRating, HR_Kpis.MaximumRating, HR_Kpis.DefaultScale FROM HR_Kpis INNER JOIN HR_JobTitle ON HR_Kpis.JobTitleID = HR_JobTitle.JobTitleID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@JobTitleID", _jobTitleID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@KeyPerformanceIndicator", _keyPerformanceIndicator, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@MinimumRating", _minimumRating, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@MaximumRating", _maximumRating, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@DefaultScale", _defaultScale, SqlDbType.Int, 50);


        string sql = "INSERT INTO [dbo].[HR_Kpis] ([JobTitleID] ,[KeyPerformanceIndicator],[MinimumRating],[MaximumRating],[DefaultScale],[CreationDate],[LastModifiedDate],[OperatorID]) values (@JobTitleID,@KeyPerformanceIndicator,@MinimumRating,@MaximumRating,@DefaultScale,@Creationdate,@LastModifiedDate,@OperatorID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(KpiID) as lastID from HR_Kpis";
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
        param[3] = DataAccess.AddParamter("@JobTitleID", _jobTitleID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@KeyPerformanceIndicator", _keyPerformanceIndicator, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@MinimumRating", _minimumRating, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@MaximumRating", _maximumRating, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@DefaultScale", _defaultScale, SqlDbType.Int, 50);


        string sql = "Update [dbo].[HR_Kpis] Set [JobTitleID]=@JobTitleID ,[KeyPerformanceIndicator]=@KeyPerformanceIndicator,[MinimumRating]=@MinimumRating,[MaximumRating]=@MaximumRating,[DefaultScale]=@DefaultScale,[LastModifiedDate]=@LastModifiedDate,[OperatorID]=@OperatorID Where KpiID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}