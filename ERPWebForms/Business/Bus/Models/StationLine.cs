using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPWebForms.Business.Bus.Models
{
    public class StationLine
    {
        public int LineId { get; set; }
        public int StationId { get; set; }
        public string Time { get; set; }
        public int OrderOnLine { get; set; }
        public int Active { get; set; }
    }
}
