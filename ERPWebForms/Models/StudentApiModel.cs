using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebForms.Models
{
    public class StudentApiModel
    {
        public class Absent
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public int StdID { get; set; }
            public int ClassID { get; set; }
        }
        public class std_Exams
        {
            public int ID { get; set; }
            public string ExamName { get; set; }
            public DateTime ExamDate { get; set; }
            public string CourseName { get; set; }
            public int Type { get; set; }
            public string ExamDegree { get; set; }
        }
        public class Std_FollowUp
        {
            public int ID { get; set; }
            public string Teacher { get; set; }
            public string Description { get; set; }
            public string CourseName { get; set; }
        }
        public class Schedules
        {
            public int ID { get; set; }
            public string Day { get; set; }
            public string Lecture1 { get; set; }
            public string Lecture2 { get; set; }
            public string Lecture3 { get; set; }
            public string Lecture4 { get; set; }
            public string Lecture5 { get; set; }
            public string Lecture6 { get; set; }
            public string Lecture7 { get; set; }
            public string Lecture8 { get; set; }
            public string Lecture9 { get; set; }
            public string Lecture10 { get; set; }
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int ParentID { get; set; }
        public string Parent { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public int ClassID { get; set; }
        public string Class { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int OperatorID { get; set; }
        public List<Course> courses { get; set; }
        public List<Document> Documents { get; set; }
        public List<std_Exams> ExamsFinal { get; set; }
        public List<std_Exams> ExamsQuiz { get; set; }
        public List<std_Exams> ExamsMidTerm { get; set; }
        public List<Absent> Absents { get; set; }
        public List<Std_FollowUp> FollowUps { get; set; }
        public List<Schedules> Schedule { get; set; }
        public System.Data.DataTable getList()
        {
            DateTime d = new DateTime(DateTime.Now.Year, 9, 30);
            string sql = "SELECT dbo.Std_Student.ID, dbo.Std_Student.Name as Name, convert(varchar(11),dbo.Std_Student.BirthDate,111) as BirthDate, dbo.Std_Parent.Name AS ParentName, dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear, dbo.Age(  dbo.Std_Student.BirthDate,CONVERT(datetime, '" + d.ToString("yyyy-MM-dd") + "', 121 )) AS age110 FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            return dt;
        }
        public int get(int id)
        {
            DateTime d = new DateTime(DateTime.Now.Year, 9, 30);
            string sql = "SELECT dbo.Std_Student.ID, dbo.Std_Student.Name as Name,dbo.Std_Student.StudClassID as StudClassID,dbo.Std_Student.OperatorID,convert(varchar(11),dbo.Std_Student.BirthDate,111) as BirthDate, convert(varchar(20),dbo.Std_Student.BirthDate,103) as BirthDate, dbo.Std_Parent.Name AS ParentName, dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear, dbo.Age(  dbo.Std_Student.BirthDate,CONVERT(datetime, '" + d.ToString("yyyy-MM-dd") + "', 121 )) AS age110,dbo.Std_Student.LastModifiedDate, dbo.Std_Student.CreationDate FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID Where dbo.Std_Student.ID=" + id;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                CreationDate = DateTime.Parse(dt.Rows[0]["CreationDate"].ToString());
                LastModifiedDate = DateTime.Parse(dt.Rows[0]["LastModifiedDate"].ToString());
                OperatorID = int.Parse(dt.Rows[0]["OperatorID"].ToString());
                ID = id;
                Name = dt.Rows[0]["Name"].ToString();
                Parent = dt.Rows[0]["ParentName"].ToString();
                Address = dt.Rows[0]["Address"].ToString();
                Phone = dt.Rows[0]["Phone"].ToString();
                Type = dt.Rows[0]["StdType"].ToString();
                Class = dt.Rows[0]["ClassName"].ToString();
                ClassID = Convert.ToInt32(dt.Rows[0]["StudClassID"].ToString());
                DateTime d2 = DateTime.Now;
                d2 = DateTime.Parse(dt.Rows[0]["BirthDate"].ToString());
                BirthDate = d;
                Phone = dt.Rows[0]["Phone"].ToString();
                Absents = getAbsents(id);
                ExamsFinal = getExams(id,0);
                ExamsQuiz = getExams(id, 1);
                ExamsMidTerm = getExams(id, 2);
                courses = getStd_Courses(id);
                Documents = getStd_CourseDoc(ClassID);
                FollowUps = getStd_FollowUps(id);
                Schedule = getStd_Schedule(id);
            }
            return id;
        }

        public List<Schedules> getStd_Schedule(int StdID)
        {
            List<Schedules> Schedule = new List<Schedules>();
            string sql = "SELECT dbo.Std_ClassSchedule.ID, dbo.Std_ClassSchedule.Day," +
                         "(SELECT Name FROM dbo.Std_Course  WHERE (ID = dbo.Std_ClassSchedule.Lecture1)) AS Lecture1," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_9 WHERE (ID = dbo.Std_ClassSchedule.Lecture2)) AS Lecture2," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_8 WHERE (ID = dbo.Std_ClassSchedule.Lecture3)) AS Lecture3," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_7 WHERE (ID = dbo.Std_ClassSchedule.Lecture4)) AS Lecture4," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_6 WHERE (ID = dbo.Std_ClassSchedule.Lecture5)) AS Lecture5," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_5 WHERE (ID = dbo.Std_ClassSchedule.Lecture6)) AS Lecture6," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_4 WHERE (ID = dbo.Std_ClassSchedule.Lecture7)) AS Lecture7," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_3 WHERE (ID = dbo.Std_ClassSchedule.Lecture8)) AS Lecture8," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_2 WHERE (ID = dbo.Std_ClassSchedule.Lecture9)) AS Lecture9," +
                         "(SELECT Name FROM dbo.Std_Course AS Std_Course_1 WHERE (ID = dbo.Std_ClassSchedule.Lecture10)) AS Lecture10" +
                         " FROM dbo.Std_ClassSchedule INNER JOIN dbo.Std_Student ON dbo.Std_ClassSchedule.classID = dbo.Std_Student.StudClassID" +
                         " WHERE (dbo.Std_Student.ID = " + StdID + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Schedules s = new Schedules();
                s.ID = Convert.ToInt32(dr["ID"].ToString());
                s.Day = dr["Day"].ToString();
                s.Lecture1 = dr["Lecture1"].ToString();
                s.Lecture2 = dr["Lecture2"].ToString();
                s.Lecture3 = dr["Lecture3"].ToString();
                s.Lecture4 = dr["Lecture4"].ToString();
                s.Lecture5 = dr["Lecture5"].ToString();
                s.Lecture6 = dr["Lecture6"].ToString();
                s.Lecture7 = dr["Lecture7"].ToString();
                s.Lecture8 = dr["Lecture8"].ToString();
                s.Lecture9 = dr["Lecture9"].ToString();
                s.Lecture10 = dr["Lecture10"].ToString();
                Schedule.Add(s);
            }
            return Schedule;
        }

        public List<Std_FollowUp> getStd_FollowUps(int StdID)
        {
            List<Std_FollowUp> followup = new List<Std_FollowUp>();
            string sql = "SELECT     dbo.Std_FollowUp.ID, dbo.Std_Teacher.Name AS Teacher, dbo.Std_FollowUp.Description, dbo.Std_Course.Name AS courseName" +
                         " FROM         dbo.Std_FollowUp INNER JOIN dbo.Std_Teacher ON dbo.Std_FollowUp.TeacherID = dbo.Std_Teacher.ID INNER JOIN" +
                         " dbo.Std_Course ON dbo.Std_FollowUp.CourseID = dbo.Std_Course.ID WHERE (dbo.Std_FollowUp.StudentID = " + StdID + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Std_FollowUp f = new Std_FollowUp();
                f.ID = Convert.ToInt32(dr["ID"].ToString());
                f.Teacher = dr["Teacher"].ToString();
                f.Description = dr["Description"].ToString();
                f.CourseName = dr["courseName"].ToString();
                followup.Add(f);
            }
            return followup;
        }
        public List<Absent> getAbsents(int StdID)
        {
            List<Absent> StdAbsents = new List<Absent>();
            string sql = "select * from Std_Absent where StudentID = " + StdID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Absent s = new Absent();
                s.ID = Convert.ToInt32(dr["ID"].ToString());
                s.Date = Convert.ToDateTime(dr["AbsentDate"].ToString());
                StdAbsents.Add(s);
            }
            return StdAbsents;
        }
        public List<std_Exams> getExams(int StdID, int type)
        {
            List<std_Exams> Std_Exams = new List<std_Exams>();
            string sql = "SELECT dbo.Std_Exam.ID, dbo.Std_Course.Name AS Course_Name, dbo.Std_Student.ID AS StdID, dbo.Std_Student.Name AS StdName, dbo.Std_Exam.Name AS ExamName, dbo.Std_Exam.ExamDate, dbo.Std_ExamDegree.Degree, dbo.Std_Exam.Type" +
                         " FROM dbo.Std_Exam INNER JOIN dbo.Std_ExamClasses ON dbo.Std_ExamClasses.ExamID = dbo.Std_Exam.ID INNER JOIN" +
                          " dbo.std_examCourses ON dbo.std_examCourses.ExamID = dbo.Std_Exam.ID INNER JOIN" +
                            " dbo.Std_Course ON dbo.std_examCourses.CourseID = dbo.Std_Course.ID INNER JOIN" +
                      " dbo.Std_Student ON dbo.Std_ExamClasses.ClassID = dbo.Std_Student.StudClassID LEFT OUTER JOIN" +
                      " dbo.Std_ExamDegree ON dbo.Std_ExamDegree.ExamCourseID = dbo.std_examCourses.ID AND dbo.Std_ExamDegree.StdID = dbo.Std_Student.ID" +
                        " GROUP BY dbo.Std_Exam.ID, dbo.Std_Course.Name, dbo.Std_Student.ID, dbo.Std_Student.Name, dbo.Std_Exam.Name, dbo.Std_Exam.ExamDate, dbo.Std_ExamDegree.Degree, dbo.Std_Exam.Type" +
                        " HAVING (dbo.Std_Student.ID = " + StdID + ") AND (dbo.Std_Exam.Type = " + type + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                std_Exams e = new std_Exams();

                e.ID = Convert.ToInt32(dr["ID"].ToString());
                e.ExamDate = Convert.ToDateTime(dr["ExamDate"].ToString());
                e.CourseName = dr["Course_Name"].ToString();
                e.ExamName = dr["ExamName"].ToString();
                e.ExamDegree = dr["Degree"].ToString();

                Std_Exams.Add(e);
            }
            return Std_Exams;
        }
        public List<Course> getStd_Courses(int StdID)
        {
            List<Course> StdCourses = new List<Course>();
            string sql = "SELECT     dbo.Std_Course.ID, dbo.Std_Course.Name, dbo.Std_Course.Description, dbo.Std_ClassCourses.TeacherID, dbo.Std_ClassCourses.ClassID FROM dbo.Std_ClassCourses LEFT OUTER JOIN dbo.Std_Student ON dbo.Std_ClassCourses.ClassID = dbo.Std_Student.StudClassID RIGHT OUTER JOIN dbo.Std_Course ON dbo.Std_ClassCourses.CourseID = dbo.Std_Course.ID WHERE     (dbo.Std_Student.ID = " + StdID.ToString() + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Course c = new Course();

                c.ID = Convert.ToInt32(dr["ID"].ToString());
                c.Name = dr["Name"].ToString();
                c.Description = dr["Description"].ToString();
                //   c.ExamName = dr["Name"].ToString();
                //e.ExamDegree = Convert.ToDecimal(dr["Degree"].ToString());
                StdCourses.Add(c);
            }
            return StdCourses;
        }
        public List<Document> getStd_CourseDoc(int StdID)
        {
            List<Document> docs = new List<Document>();
            string sql = "SELECT dbo.Std_CourseDocuments.ID, dbo.Std_CourseDocuments.Name, dbo.Std_CourseDocuments.URl, dbo.Std_CourseDocuments.CourseID, dbo.Std_CourseDocuments.ClassID, dbo.Std_Course.Name AS CourseName"+
                         " FROM dbo.Std_CourseDocuments INNER JOIN dbo.Std_Course ON dbo.Std_CourseDocuments.ID = dbo.Std_Course.ID WHERE (ClassID= " + StdID.ToString() + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);

            foreach (DataRow dr in dt.Rows)
            {
                Document doc = new Document();
                doc.ID = Convert.ToInt32(dr["ID"].ToString());
                doc.Name = dr["Name"].ToString();
                doc.URL = dr["URL"].ToString();
                doc.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                doc.CourseName = dr["CourseName"].ToString();
                docs.Add(doc);
            }
            return docs;
        }


    }
}