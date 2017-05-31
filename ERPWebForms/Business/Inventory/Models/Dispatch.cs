using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class Dispatch:BaseModel
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public int StuffID { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }
        public int Active { get; set; }
    }
}