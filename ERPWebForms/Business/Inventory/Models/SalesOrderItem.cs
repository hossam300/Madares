using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class SalesOrderItem:BaseModel
    {
        public int SalesOrderID { get; set; }
        public int ProductWarehouseID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Active { get; set; }

    }
}