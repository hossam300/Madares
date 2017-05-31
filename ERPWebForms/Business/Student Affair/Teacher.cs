using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Teacher
/// </summary>
public class Teacher : baseObject
{
    public Teacher()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    string _phone;

    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    DataTable _courses;

    public DataTable Courses
    {
        get { return _courses; }
        set { _courses = value; }
    }
    public override int get(int id)
    {
        string sql = "select * from Std_Teacher Where ID=" + id;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _name = dt.Rows[0]["Name"].ToString();
            _email = dt.Rows[0]["Email"].ToString();
            _phone = dt.Rows[0]["Phone"].ToString();
            _address = dt.Rows[0]["address"].ToString();
            sql = "SELECT     dbo.Std_Course.ID, dbo.Std_Course.Name, dbo.Std_Course.Description, dbo.Std_Course.min, dbo.Std_Course.max FROM dbo.Std_TeacherCourses INNER JOIN  dbo.Std_Course ON dbo.Std_TeacherCourses.CourseID = dbo.Std_Course.ID Where  dbo.Std_TeacherCourses.TeacherID=" + id;
            _courses = DataAccess.ExecuteSQLQuery(sql);

        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Std_Teacher";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Email", _email, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 250);

        string sql = "insert into Std_Teacher(CreationDate,LastModifiedDate,OperatorID,Name,Email,Address,Phone) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Email,@Address,@Phone)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Teacher";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save the teacher courses
            for (int i = 0; i < _courses.Rows.Count; i++)
            {
                sql = "insert into Std_TeacherCourses(TeacherID,CourseID) values(" + _id.ToString() + "," + _courses.Rows[i]["CourseID"].ToString() + ")";
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
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Email", _email, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 250);

        string sql = " Update Std_Teacher set LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Name=@Name,Email=@Email,Address=@Address,Phone=@Phone Where ID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
       /* sql = "select max(id)as lastID from Std_Teacher";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {*/
          //  _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save the teacher courses
            sql = "Delete From Std_TeacherCourses Where TeacherID=" + _id;
            DataAccess.ExecuteSQLNonQuery(sql);
            for (int i = 0; i < _courses.Rows.Count; i++)
            {
                sql = "insert into Std_TeacherCourses(TeacherID,CourseID) values(" + _id.ToString() + "," + _courses.Rows[i]["CourseID"].ToString() + ")";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
        //}
        return _id;

    }
}