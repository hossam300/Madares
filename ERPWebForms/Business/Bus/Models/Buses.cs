using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Models
{
    public class Buses:BaseModel
    {
        public string BusNumber { get; set; }
        public DateTime? EndLicenseDate { get; set; }
        public int NumberOfSeats { get; set; }
        public string BusCondition { get; set; }
        public int DriverId { get; set; }
        public int Active { get; set; }
    }
}