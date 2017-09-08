using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Bus.Models
{
    public class BusLine:BaseModel
    {
        public string Name { get; set; }
        public int StartStationId { get; set; }
        public int SupervisorId { get; set; }
        public List<StationLine> StationsLines { get; set; }
        public int Active { get; set; }
    }
}