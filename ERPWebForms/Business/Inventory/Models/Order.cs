using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class Order:BaseModel
    {
        public int SupplierID { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Status { get; set; }
        public string RejectReason { get; set; }
        public string Remarks { get; set; }
        public int Active { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}