using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class OrderItem:BaseModel
    {
        public int OrderID { get; set; }
        public int ProductWarehouseID { get; set; }
        public double Cost { get; set; }
        public int Amount { get; set; }
        public int Active { get; set; }
    }
}