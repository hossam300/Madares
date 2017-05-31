using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class StoreKeeper:BaseModel
    {
        public string Name { get; set; }
        public int Active { get; set; }
    }
}