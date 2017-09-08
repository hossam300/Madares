using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Models
{
    public class BaseModel 
    {
        public int ID { get; set; }
        public int Active { get; set; }
        public int OperatorID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}