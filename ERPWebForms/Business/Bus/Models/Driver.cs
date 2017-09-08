using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Models
{
    public class Driver:BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? LicenseEndDate { get; set; }
        public DateTime DateHiring { get; set; }
        public DateTime EndHiring { get; set; }
        public int Active { get; set; }
    }
}