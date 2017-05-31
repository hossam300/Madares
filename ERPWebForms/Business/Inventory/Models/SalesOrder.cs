using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class SalesOrder:BaseModel
    {
        public int CustomerID { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Remarks { get; set; }
        public int Active { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; }
    }
}