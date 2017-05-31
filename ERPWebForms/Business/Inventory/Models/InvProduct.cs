using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class InvProduct : BaseModel
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int StockAmount { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public int Category { get; set; }
        public int Active { get; set; }
        public int LowQuantity { get; set; }
        public List<ProductWatehouse> productWatehouse { get; set; }

    }
}