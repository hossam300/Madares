using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWebForms.Models;
using System.Data;
namespace ERPWebForms.Controllers
{
    public class ParentController : ApiController
    {
        // GET api/parent
        public List<ParentApiModel> Get()
        {
            List<ParentApiModel> Parents = new List<ParentApiModel>();
            ParentApiModel p1 = new ParentApiModel();
            DataTable dt = p1.getList();
            foreach (DataRow dr in dt.Rows)
            {
                ParentApiModel p = new ParentApiModel();
                p.get(Convert.ToInt32(dr["ID"]));
                Parents.Add(p);
            }
            return Parents;
        }

        // GET api/parent/5
        public ParentApiModel Get(int id)
        {
            ParentApiModel parent = new ParentApiModel();
            parent.get(id);
            return parent;
        }

        // POST api/parent
        public void Post([FromBody]string value)
        {
        }

        // PUT api/parent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/parent/5
        public void Delete(int id)
        {
        }
    }
}
