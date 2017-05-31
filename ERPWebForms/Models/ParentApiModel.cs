using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebForms.Models
{
    public class ParentApiModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public List<StudentApiModel> Students { get; set; }

        public  int get(int id)
        {
            string sql = "select * from std_parent Where ID=" + id;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                ID = id;
                Name = dt.Rows[0]["Name"].ToString();
                Email = dt.Rows[0]["Email"].ToString();
                Phone = dt.Rows[0]["Phone"].ToString();
                Address = dt.Rows[0]["address"].ToString();
                Job = dt.Rows[0]["Job"].ToString();
                Students = getStudentforparent(id);

            }
            return id;
        }

        private List<StudentApiModel> getStudentforparent(int id)
        {
            List<StudentApiModel> Student = new List<StudentApiModel>();
            string sql = "SELECT dbo.Std_Student.ID, dbo.Std_Student.Name, dbo.Std_Student.BirthDate, dbo.Std_Student.Phone, dbo.Std_StudentType.Name AS Type, dbo.Std_Class.Name AS Class"+
                         " FROM dbo.Std_Student INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN"+
                         " dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID Where (ParentID =" + id + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                StudentApiModel s = new StudentApiModel();
                s.ID = Convert.ToInt32(dr["ID"].ToString());
                s.Name = dr["Name"].ToString();
                s.Phone = dr["Phone"].ToString();
                s.BirthDate = Convert.ToDateTime(dr["BirthDate"].ToString());
                s.Type = dr["Type"].ToString();
                s.Class = dr["Class"].ToString();
                Student.Add(s);
            }
            return Student;
        }

        public DataTable getList()
        {
            string sql = "select * from std_parent";
            return DataAccess.ExecuteSQLQuery(sql);
        }


    }
}