using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class ProductWatehouse : BaseModel
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public int Active { get; set; }
    }
}