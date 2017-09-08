using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Models
{
    public class Station:BaseModel
    {
        public string Name { get; set; }
        public int Active { get; set; }
    }
}