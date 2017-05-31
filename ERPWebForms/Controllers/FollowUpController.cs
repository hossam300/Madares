using ERPWebForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace ERPWebForms.Controllers
{
    public class FollowUpController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public List<FollowUpsApiModel> Get(int id)
        {
            List<FollowUpsApiModel> followup = new List<FollowUpsApiModel>();
            FollowUpsApiModel f = new FollowUpsApiModel();
             DataTable dt= f.getlist(id);
             foreach (DataRow dr in dt.Rows)
             {
                 FollowUpsApiModel f1 = new FollowUpsApiModel();
                 f1.get(Convert.ToInt32(dr["ID"]));
                 followup.Add(f1);
             }
           
            return followup;
            
        }

        // POST api/<controller>
        public void Post([FromBody] FollowUpsApiModel c)
        {
           
            c.CreationDate = DateTime.Now;
            c.LastModifiedDate = DateTime.Now;
            c.save();
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