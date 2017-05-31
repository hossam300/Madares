using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StdClass
/// </summary>
public class StdClass:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    DataTable _coursesTeachers;

    public DataTable CoursesTeachers
    {
        get { return _coursesTeachers; }
        set { _coursesTeachers = value; }
    }

    int _edID;

    public int EdID
    {
        get { return _edID; }
        set { _edID = value; }
    }

    int _supID;

    public int SupID
    {
        get { return _supID; }
        set { _supID = value; }
    }
    DataTable _classSchedule;
    public DataTable ClassSchedule {
        get { return _classSchedule; }
        set { _classSchedule = value; }
    }
    
	public StdClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "SELECT  *  FROM [dbo].[Std_Class] where ID="+id;

        DataTable dt= DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["Name"].ToString();
            int.TryParse(dt.Rows[0]["EdyID"].ToString(), out _edID);
            int.TryParse(dt.Rows[0]["SupID"].ToString(), out _supID);

            sql = " select *,Std_Course.Name As CourseName,TeacherID as TeacherName from Std_ClassCourses inner join std_course on std_course.ID = CourseID where ClassID=" + id.ToString();
            _coursesTeachers = DataAccess.ExecuteSQLQuery(sql);
        }
        return id;
    }
   
    public override System.Data.DataTable getList()
    {
        string sql = "SELECT     dbo.Std_Class.ID, dbo.Std_Class.Name, dbo.Std_EducationalYear.YearName, dbo.Std_Teacher.Name AS Supervisor FROM         dbo.Std_Class LEFT OUTER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID LEFT OUTER JOIN dbo.Std_Teacher ON dbo.Std_Class.SupID = dbo.Std_Teacher.ID";

        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@EdyID", _edID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@SupID", _supID, SqlDbType.Int, 50);


        string sql = "insert into Std_Class(CreationDate,LastModifiedDate,OperatorID,Name,EdyID,SupID) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@EdyID,@SupID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Class";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            for (int i = 0; i < _coursesTeachers.Rows.Count; i++)
            {
                sql = "insert into Std_ClassCourses (CourseID,TeacherID,ClassID) values("+_coursesTeachers.Rows[i]["ID"].ToString()+","+_coursesTeachers.Rows[i]["TeacherName"].ToString()+","+_id.ToString()+")";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@EdyID", _edID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@SupID", _supID, SqlDbType.Int, 50);


        string sql = "update Std_Class set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,Name=@Name,EdyID = @EdyID,SupID = @SupID where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        
        sql = "delete from Std_ClassCourses where ClassID = " + _id.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
        if(_coursesTeachers != null && _coursesTeachers.Rows != null && _coursesTeachers.Rows.Count>0)
        {
            for (int i = 0; i < _coursesTeachers.Rows.Count; i++)
            {
                sql = "insert into Std_ClassCourses (CourseID,TeacherID,ClassID) values(" + _coursesTeachers.Rows[i]["ID"].ToString() + "," + _coursesTeachers.Rows[i]["TeacherName"].ToString() + "," + _id.ToString() + ")";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
        }
        return _id;
        
    }
    public int getSchdulebyclass(int id)
    {
        string sql = "SELECT  ID,Day,Lecture1,Lecture2,Lecture3,Lecture4,Lecture5,Lecture6,Lecture7,Lecture8,Lecture9,Lecture10  FROM [dbo].[Std_ClassSchedule] where classID=" + id;

        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
           /* DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);*/
            _id = id;
            _classSchedule = dt;

        }
        return id;
    }
   
    public  int updateSchdulebyclass()
    {
        string sql = "";
        SqlParameter[] param = new SqlParameter[_classSchedule.Columns.Count+3];
        if (_classSchedule != null && _classSchedule.Rows != null && _classSchedule.Rows.Count > 0)
        {
            sql = "Delete From Std_ClassSchedule where classID=" + _id;
            DataAccess.ExecuteSQLNonQuery(sql);
            string fields = "",values ="";
            for (int i = 0; i < _classSchedule.Rows.Count; i++)
            {
                fields = "";
                values = "";
                param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                param[3] = DataAccess.AddParamter("@Day", _classSchedule.Rows[i]["Day"], SqlDbType.NVarChar, 500);
                param[4] = DataAccess.AddParamter("@ClassID", _id, SqlDbType.Int, 50);
                for (int j = 1; j < _classSchedule.Columns.Count - 1; j++)
                {
                    param[j + 4] = DataAccess.AddParamter("@Lecture" + j.ToString(), _classSchedule.Rows[i]["Lecture" + j.ToString()], SqlDbType.NVarChar, 500);
                    fields += "Lecture" + j.ToString() + ",";
                    values += "@Lecture" + j.ToString() + ",";
                }
                fields = fields.Substring(0, fields.Length - 1);
                values = values.Substring(0, values.Length - 1);
                sql = "insert into Std_ClassSchedule (CreationDate,LastModifiedDate,OperatorID,Day,classID,"+fields+") values(@CreationDate,@LastModifiedDate,@OperatorID,@Day,@classID,"+values+")";
                DataAccess.ExecuteSQLNonQuery(sql, param);
            }

        }
        return _id;
    }

    public void moveNextYear(int oldClassID, int newClassID)
    {
        //get customer ID

        string sql = "select CusID from Int_StdCustomer inner join Std_Student on Std_Student.ID = StdID where Std_Student.StudClassID = " + oldClassID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);

        sql = "update Std_Student set StudClassID = " + newClassID.ToString() +" where StudClassID = " +oldClassID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
        //insert the new customer item in Finance_Module
        if(dt != null && dt.Rows!= null && dt.Rows.Count>0)
        {
            Student std = new Student();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                std.InsertCustomerItem(int.Parse(dt.Rows[i]["CusID"].ToString()),newClassID);
            }
        }

    }

    public int getNoOfLec(int p)
    {
        int noOfLec = 0;
        string sql = "select NoOfLec from Std_EducationalYear inner join Std_Class on Std_Class.EdyID = Std_EducationalYear.ID where Std_Class.ID =" + p.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            int.TryParse(dt.Rows[0]["NoOfLec"].ToString(), out noOfLec);
        }
        return noOfLec;
    }

    public DataTable GetCourses(int p)
    {
        string sql = "SELECT Std_Course.ID, Std_Course.Name, Std_Course.Description, Std_Course.min, Std_Course.max FROM  Std_CourseEdy INNER JOIN  Std_Course ON Std_CourseEdy.CourseID = Std_Course.ID inner join Std_Class on Std_Class.EdyID = Std_CourseEdy.EdyID WHERE     (Std_Class.ID =" + p.ToString() + ")";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
}