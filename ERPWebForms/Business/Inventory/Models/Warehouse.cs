using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class Warehouse : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int StoreKeeper { get; set; }
        public int Active { get; set; }
        public List<ProductWatehouse> productWatehouse { get; set; }

    }
}