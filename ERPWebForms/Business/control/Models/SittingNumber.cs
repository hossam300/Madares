using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Models
{
    public class SittingNumber : BaseModel
    {
        public int StudentId { get; set; }
        public string Number { get; set; }
    }
}