using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    int _min;

    public int Min
    {
        get { return _min; }
        set { _min = value; }
    }
    int _max;

    public int Max
    {
        get { return _max; }
        set { _max = value; }
    }
    DataTable _edy;

    public DataTable Edy
    {
        get { return _edy; }
        set { _edy = value; }
    }
    DataTable _teachers;
    public DataTable Teachers
    {
        get { return _teachers; }
        set { _teachers = value; }
    }
    DataTable _documents;
    public DataTable Docments
    {
        get { return _documents; }
        set { _documents = value; }
    }
	public Course()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "Select * From Std_Course Where ID="+id;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["Name"].ToString();
            _description = dt.Rows[0]["Description"].ToString();
            int.TryParse(dt.Rows[0]["min"].ToString(), out _min);
            int.TryParse(dt.Rows[0]["max"].ToString(), out _max);
            sql = " SELECT     dbo.Std_EducationalYear.ID, dbo.Std_EducationalYear.YearName, dbo.Std_EducationalYear.Rank, dbo.Std_EducationalYear.NoOfLec, dbo.Std_EducationalYear.LecPeriodMin FROM dbo.Std_CourseEdy INNER JOIN dbo.Std_EducationalYear ON dbo.Std_CourseEdy.EdyID = dbo.Std_EducationalYear.ID WHERE     (dbo.Std_CourseEdy.CourseID = " + id + ")";
            Edy = DataAccess.ExecuteSQLQuery(sql);
            sql = "SELECT     dbo.Std_Teacher.ID, dbo.Std_Teacher.Name, dbo.Std_Teacher.Phone, dbo.Std_Teacher.Email, dbo.Std_Teacher.address FROM  dbo.Std_TeacherCourses INNER JOIN dbo.Std_Teacher ON dbo.Std_TeacherCourses.TeacherID = dbo.Std_Teacher.ID Where  dbo.Std_TeacherCourses.CourseID="+id;
            _teachers = DataAccess.ExecuteSQLQuery(sql);
            sql = "SELECT     dbo.Std_CourseDocuments.ID, dbo.Std_CourseDocuments.Name, dbo.Std_CourseDocuments.URl, dbo.Std_CourseDocuments.CreationDate, dbo.Std_CourseDocuments.LastModifiedDate, dbo.Std_CourseDocuments.OperatorID FROM dbo.Std_CourseDocuments INNER JOIN dbo.Std_Course ON dbo.Std_CourseDocuments.CourseID = dbo.Std_Course.ID where  dbo.Std_Course.ID=@ID";
            _documents = DataAccess.ExecuteSQLQuery(sql);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Std_Course";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@min", _min, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@max", _max, SqlDbType.Int, 50);


        string sql = "insert into Std_Course(CreationDate,LastModifiedDate,OperatorID,Name,Description,min,max) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Description,@min,@max)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Course";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //add the educational years for this course
            for (int i = 0; i < Edy.Rows.Count; i++)
            {
                sql = "insert into Std_CourseEdy(CourseID,EdyID)values("+_id.ToString()+","+Edy.Rows[i]["edyID"].ToString()+")";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID",_id, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@min", _min, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@max", _max, SqlDbType.Int, 50);


        string sql = "Update  Std_Course Set LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Name=@Name,Description=@Description,min=@min,max=@max Where ID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
       
        
            
            // Delete the educational years for this course
            sql = "Delete From Std_CourseEdy Where CourseID="+_id;
        DataAccess.ExecuteSQLNonQuery(sql);
            //add the educational years for this course
            for (int i = 0; i < Edy.Rows.Count; i++)
            {
                sql = "insert into Std_CourseEdy(CourseID,EdyID)values(" + _id.ToString() + "," + Edy.Rows[i]["edyID"].ToString() + ")";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
            return _id;
       
    }
}