using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Models
{
    public class floor : BaseModel
    {
        public string Name { get; set; }
        public int SupervisorId { get; set; }

    }
}