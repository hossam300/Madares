using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JobCategory
/// </summary>
public class JobCategories : baseObject
{
    string _jobCategory;

    public string JobCategoies
    {
        get { return _jobCategory; }
        set { _jobCategory = value; }
    }
    public JobCategories()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_JobCategory where JobCategoryID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _jobCategory = dt.Rows[0]["JobCategory"].ToString();
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_JobCategory ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@JobCategory", _jobCategory, SqlDbType.NVarChar, 500);

        string sql = "INSERT INTO [HR_JobCategory] ([JobCategory] ,[CreationDate],[LastModifiedDate],[OperatorID]) values (@JobCategory,@Creationdate,@LastModifiedDate,@OperatorID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(JobCategoryID)as lastID from HR_JobCategory";
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
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@JobCategory", _jobCategory, SqlDbType.NVarChar, 500);

        string sql = "UPDATE [HR_JobCategory] SET [JobCategory] = @JobCategory,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  WHERE JobCategoryID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}