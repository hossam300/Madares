using ERPWebForms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPWebForms.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>
        public List<StudentApiModel> Get()
        {

            List<StudentApiModel> students = new List<StudentApiModel>();
            StudentApiModel s1 = new StudentApiModel();
            //string sql = "select * from Std_Student";
            DataTable dt = s1.getList();
         //   List<Student> retval = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                StudentApiModel s = new StudentApiModel();
                s.get(Convert.ToInt32(dr["ID"]));
            students.Add(s);
            }

            return students;

          
        
        }
        // GET api/<controller>/5
        public StudentApiModel Get(int id)
        {
            StudentApiModel student = new StudentApiModel();
             student.get(id);
             return student;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}