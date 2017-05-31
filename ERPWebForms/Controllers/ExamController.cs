using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPWebForms.Controllers
{
    public class ExamController : ApiController
    {
        public List<Exam> Get()
        {
            List<Exam> exams = new List<Exam>();
            Exam e = new Exam();
            DataTable dt = e.getList();
          
            foreach (DataRow dr in dt.Rows)
            {
                Exam exam = new Exam();
                exam.get(Convert.ToInt32(dr["ID"]));
                exams.Add(exam);
            }
            return exams;
       }
        public Exam Get(int id)
        {
            Exam exam = new Exam();
            exam.get(id);
            return exam;
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
