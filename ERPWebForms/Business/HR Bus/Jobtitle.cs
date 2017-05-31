using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Jobtitle
/// </summary>
public class Jobtitle:baseObject
{
    string _jobTitle;

    public string JobTitle
    {
        get { return _jobTitle; }
        set { _jobTitle = value; }
    }
    string _jobSpecification;

    public string JobSpecification
    {
        get { return _jobSpecification; }
        set { _jobSpecification = value; }
    }
    string _jobDescription;

    public string JobDescription
    {
        get { return _jobDescription; }
        set { _jobDescription = value; }
    }
    string _note;

    public string Note
    {
        get { return _note; }
        set { _note = value; }
    }
	public Jobtitle()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_JobTitle where JobTitleID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _jobTitle = dt.Rows[0]["JobTitle"].ToString();
            _jobSpecification = dt.Rows[0]["JobSpecification"].ToString();
            _jobDescription = dt.Rows[0]["JobDescription"].ToString();
            _note = dt.Rows[0]["Note"].ToString();
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_JobTitle ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@JobTitle", _jobTitle, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@JobSpecification", _jobSpecification, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@JobDescription", _jobDescription, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Note", _note, SqlDbType.NVarChar, 500);

        string sql = "INSERT INTO [HR_JobTitle] ([JobTitle],[JobSpecification],[JobDescription],[Note] ,[CreationDate],[LastModifiedDate],[OperatorID]) values (@JobTitle,@JobSpecification,@JobDescription,@Note,@Creationdate,@LastModifiedDate,@OperatorID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(JobTitleID)as lastID from HR_JobTitle";
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
        param[3] = DataAccess.AddParamter("@JobTitle", _jobTitle, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@JobSpecification", _jobSpecification, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@JobDescription", _jobDescription, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Note", _note, SqlDbType.NVarChar, 500);
        string sql = "UPDATE [HR_JobTitle] SET [JobTitle] = @JobTitle,[JobSpecification] = @JobSpecification,[JobDescription] = @JobDescription,[Note] = @Note,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  WHERE JobTitleID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(JobTitleID)as lastID from HR_JobTitle";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return _id;
    }
}