using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class InvCustomer:BaseModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public int Active { get; set; }
    }
}