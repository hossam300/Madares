using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Models
{
    public class StudentLine : BaseModel
    {
        public int LineId { get; set; }
        public int StudentId { get; set; }
        public int StationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public int Active { get; set; }
    }
}