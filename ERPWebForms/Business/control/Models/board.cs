using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.control.Models
{
    public class board : BaseModel
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int StudentNum { get; set; }
        public List<StudentBord> StudentBords { get; set; }
        public int FloorId { get; set; }
    }
}