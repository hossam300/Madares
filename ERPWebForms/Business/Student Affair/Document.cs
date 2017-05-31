using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Documents
/// </summary>
public class Document:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _url;

    public string URL
    {
        get { return _url; }
        set { _url = value; }
    }
     int _courseID;
     public int CourseID {
         get { return _courseID; }
         set { _courseID = value; }
     }
     string _courseName;
     public string CourseName
     {
         get { return _courseName; }
         set { _courseName = value; }
     }
     int _classID;
     public int ClassID {
         get { return _classID; }
         set {_classID=value;}
     }
	public Document()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "Select * From Std_CourseDocuments Where ID=" + id;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["Name"].ToString();
           _url = dt.Rows[0]["URL"].ToString();
           int.TryParse(dt.Rows[0]["CourseID"].ToString(), out _courseID);
           int.TryParse(dt.Rows[0]["ClassID"].ToString(), out _classID);
           
        }
        return id;
    }
    public DataTable getDocumentbyCourseID(int id)
    {
      string  sql = "SELECT dbo.Std_CourseDocuments.ID, dbo.Std_CourseDocuments.Name, dbo.Std_CourseDocuments.URl, dbo.Std_CourseDocuments.CreationDate, dbo.Std_CourseDocuments.LastModifiedDate, dbo.Std_CourseDocuments.OperatorID FROM dbo.Std_CourseDocuments INNER JOIN dbo.Std_Course ON dbo.Std_CourseDocuments.CourseID = dbo.Std_Course.ID where  dbo.Std_Course.ID=@ID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
    public override System.Data.DataTable getList()
    {
        string sql = "SELECT * FROM dbo.Std_CourseDocuments order by CreationDate";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@URl", _url, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@CourseID", _courseID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@ClassID", _classID, SqlDbType.Int, 50);


        string sql = "insert into dbo.Std_CourseDocuments (CreationDate,LastModifiedDate,OperatorID,Name,URl,CourseID,ClassID) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@URl,@CourseID,@ClassID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_CourseDocuments";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //add the educational years for this course
            
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
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@URl", _url, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@CourseID", _courseID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@ClassID", _classID, SqlDbType.Int, 50);


        string sql = "Update  dbo.Std_CourseDocuments Set LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Name=@Name,URl=@URl,CourseID=@CourseID,ClassID=@ClassID Where ID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}