using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class Restock:BaseModel
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int WarehouseID { get; set; }
        public double TotalCost { get; set; }
        public double UnitCost { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public int Active { get; set; }
        public string InvoiceImage { get; set; }
    }
}