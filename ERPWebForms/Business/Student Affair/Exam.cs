using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Exam
/// </summary>
public class Exam : baseObject
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
    int _type;

    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }
    int _nature;

    public int Nature
    {
        get { return _nature; }
        set { _nature = value; }
    }
    DateTime _examDate;

    public DateTime ExamDate
    {
        get { return _examDate; }
        set { _examDate = value; }
    }
    DataTable _classes;

    public DataTable Classes
    {
        get { return _classes; }
        set { _classes = value; }
    }
    int _edyID;

    public int EdyID
    {
        get { return _edyID; }
        set { _edyID = value; }
    }
    DataTable _courses;

    public DataTable Courses
    {
        get { return _courses; }
        set { _courses = value; }
    }
    public Exam()
    {
        _courses = new DataTable();
        _courses.Columns.Add("ID");
        _courses.Columns.Add("Name");

        _classes = new DataTable();
        _classes.Columns.Add("ID");
        _classes.Columns.Add("Name");

    }

    public override int get(int id)
    {
        string sql = "select * from Std_Exam where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _name = dt.Rows[0]["Name"].ToString();
            _description = dt.Rows[0]["Description"].ToString();
            int.TryParse(dt.Rows[0]["Type"].ToString(), out _type);
            int.TryParse(dt.Rows[0]["Nature"].ToString(), out _nature);
            DateTime.TryParse(dt.Rows[0]["ExamDate"].ToString(), out _examDate);
            int edyID = 0;
            int.TryParse(dt.Rows[0]["EdyID"].ToString(), out  edyID);
            _edyID = edyID;
            _classes = DataAccess.ExecuteSQLQuery("select Name,STD_Class.ID from STD_Class inner join Std_ExamClasses on STD_Class.ID = Std_ExamClasses.ClassID where ExamID = " + id.ToString());
            _courses = DataAccess.ExecuteSQLQuery("select Name,Std_Course.ID from Std_Course inner join std_examCourses on Std_Course.ID = std_examCourses.CourseID where std_examCourses.ExamID = " + id.ToString());
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Std_Exam ";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@Type", _type, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@Nature", _nature, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@ExamDate", _examDate, SqlDbType.DateTime, 50);
        param[8] = DataAccess.AddParamter("@edyID", _edyID, SqlDbType.Int, 50);


        string sql = "insert into Std_Exam(CreationDate,LastModifiedDate,OperatorID,Name,Description,Type,Nature,ExamDate,edyID) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Description,@Type,@Nature,@ExamDate,@edyID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Exam";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save exam classes
            if (_classes != null && _classes.Rows != null && _classes.Rows.Count > 0)
            {
                for (int i = 0; i < _classes.Rows.Count; i++)
                {
                    sql = "insert into std_examClasses(ExamID,ClassID) values(" + _id.ToString() + "," + _classes.Rows[i]["ID"].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
            }
            //save exam courses
            if (_courses != null && _courses.Rows != null && _courses.Rows.Count > 0)
            {
                for (int i = 0; i < _courses.Rows.Count; i++)
                {
                    sql = "insert into std_examCourses(ExamID,CourseID) values(" + _id.ToString() + "," + _courses.Rows[i]["ID"].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
            }
            return _id;
        }
        return 0;
    }
    public DataTable getExamStudents(int ExamID)
    {
        string sql = "select std_student.ID,std_student.Name from std_student inner join Std_ExamClasses on std_student.StudClassID = Std_ExamClasses.ClassID where ExamID = " + ExamID.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }
    public override int update()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@Type", _type, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@Nature", _nature, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@ExamDate", _examDate, SqlDbType.DateTime, 50);
        param[8] = DataAccess.AddParamter("@edyID", _edyID, SqlDbType.Int, 50);


        string sql = "update Std_Exam set LastModifiedDate = @LastModifiedDate,OperatorID=@OperatorID,Name=@Name,Description=@Description,Type=@Type,Nature=@Nature,ExamDate=@ExamDate,edyID=@edyID where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //save exam classes
        if (_classes != null && _classes.Rows != null && _classes.Rows.Count > 0)
        {
                string ExistClasses = "";
                for (int i = 0; i < _classes.Rows.Count; i++)
            {
                ExistClasses += " and ClassID <>" + _classes.Rows[i]["ID"].ToString();
            }
            //remove examCourses when Course not find 
                sql = "delete std_examClasses where ExamID = " + _id.ToString() + " " + ExistClasses;
            DataAccess.ExecuteSQLNonQuery(sql);
            for (int i = 0; i < _classes.Rows.Count; i++)
            {
                //sql = "Select * From std_examCourses Where ExamID=" + _id.ToString();
                //DataTable dtoldexamCourses = DataAccess.ExecuteSQLQuery(sql);
                //add examCourses when found new Course
                sql = "Select * From std_examClasses Where ExamID=" + _id.ToString() + " And ClassID=" + _classes.Rows[i]["ID"].ToString() + "";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = "insert into std_examClasses(ExamID,ClassID) Values(" + _id.ToString() + "," + _classes.Rows[i]["ID"].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
            }
            //sql = "delete std_examClasses where ExamID = " + _id.ToString();
            //DataAccess.ExecuteSQLNonQuery(sql);

            //for (int i = 0; i < _classes.Rows.Count; i++)
            //{
            //    sql = "insert into std_examClasses(ExamID,ClassID) values(" + _id.ToString() + "," + _classes.Rows[i]["ID"].ToString() + ")";
            //    DataAccess.ExecuteSQLNonQuery(sql);
            //}
        }
        //save exam courses
        if (_courses != null && _courses.Rows != null && _courses.Rows.Count > 0)
        {
            //sql = "delete std_examCourses where ExamID = " + _id.ToString();
            //DataAccess.ExecuteSQLNonQuery(sql);
            string ExistCourses = "";
            for (int i = 0; i < _courses.Rows.Count; i++)
            {
                ExistCourses += " and CourseID <>" + _courses.Rows[i]["ID"].ToString();
            }
            //remove examCourses when Course not find 
            sql = "delete std_examCourses where ExamID = " + _id.ToString() + " " + ExistCourses;
            DataAccess.ExecuteSQLNonQuery(sql);
            for (int i = 0; i < _courses.Rows.Count; i++)
            {
                //sql = "Select * From std_examCourses Where ExamID=" + _id.ToString();
                //DataTable dtoldexamCourses = DataAccess.ExecuteSQLQuery(sql);
                //add examCourses when found new Course
                sql = "Select * From std_examCourses Where ExamID=" + _id.ToString() + " And CourseID=" + _courses.Rows[i]["ID"].ToString() + "";
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if (dt.Rows.Count == 0 )
                {
                    sql = "insert into std_examCourses(ExamID,CourseID) Values(" + _id.ToString() + "," + _courses.Rows[i]["ID"].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
                //sql = "select max(id) as maxID from std_examCourses";
                //DataTable dt = DataAccess.ExecuteSQLQuery(sql);

            }
        }
        return _id;
    }
    public DataTable getExamDegree(int ExamID)
    {
        return getExamDegree(ExamID, 0);
    }
    public DataTable getExamDegree(int ExamID, int ClassID)
    {
        string sql = "SELECT     dbo.std_examCourses.ID, dbo.Std_Course.Name AS courseName, dbo.Std_Student.ID AS StdID, dbo.Std_Student.Name AS StdName, dbo.Std_Exam.Name AS ExamName,  dbo.Std_Exam.ID AS ExamCourseID, dbo.Std_ExamDegree.Degree, dbo.Std_ExamClasses.ClassID FROM dbo.Std_Exam INNER JOIN dbo.Std_ExamClasses ON dbo.Std_ExamClasses.ExamID = dbo.Std_Exam.ID INNER JOIN dbo.std_examCourses ON dbo.std_examCourses.ExamID = dbo.Std_Exam.ID INNER JOIN dbo.Std_Course ON dbo.std_examCourses.CourseID = dbo.Std_Course.ID INNER JOIN dbo.Std_Student ON dbo.Std_ExamClasses.ClassID = dbo.Std_Student.StudClassID LEFT OUTER JOIN dbo.Std_ExamDegree ON dbo.Std_ExamDegree.ExamCourseID = dbo.std_examCourses.ID AND dbo.Std_ExamDegree.StdID = dbo.Std_Student.ID GROUP BY dbo.std_examCourses.ID, dbo.Std_Course.Name, dbo.Std_Student.ID, dbo.Std_Student.Name, dbo.Std_Exam.Name, dbo.Std_Exam.ID, dbo.Std_ExamDegree.Degree,dbo.Std_ExamClasses.ClassID HAVING (dbo.Std_Exam.ID =  " + ExamID.ToString() + ")";
        if (ClassID != 0)
        {
            sql += " and Std_ExamClasses.ClassID = " + ClassID.ToString();
        }
        sql += " order by Std_Student.ID";

        return DataAccess.ExecuteSQLQuery(sql);
    }


    public int saveExamDegree(DataTable examDegree, int ExamID, int classID)
    {
        string sql = "delete from Std_ExamDegree where ExamCourseID in (select ID from std_examCourses where ExamID = " + ExamID.ToString() + ") and StdID in (select ID from Std_Student where StudClassID = " + classID.ToString() + ")";
        DataAccess.ExecuteSQLNonQuery(sql);
        DataTable dt;
        for (int i = 0; i < examDegree.Rows.Count; i++)
        {
            for (int j = 0; j < examDegree.Columns.Count; j++)
            {
                if (examDegree.Columns[j].ColumnName != "ID" && examDegree.Columns[j].ColumnName != "StudentName" && examDegree.Columns[j].ColumnName != "Total" && examDegree.Columns[j].ColumnName != "ExamCourseID")
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = DataAccess.AddParamter("@Name", examDegree.Columns[j].ColumnName, SqlDbType.NVarChar, 500);
                    sql = "select ID from std_examCourses where ExamID = " + ExamID.ToString() + " and CourseID in(select ID from Std_Course where Name = @Name)";
                    dt = DataAccess.ExecuteSQLQuery(sql, param);
                    sql = "insert into Std_ExamDegree(ExamCourseID,StdID,Degree) values(  " + dt.Rows[0]["ID"].ToString() + "," + examDegree.Rows[i]["ID"].ToString() + "," + examDegree.Rows[i][examDegree.Columns[j].ColumnName].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
            }
        }
        return 1;
    }
}