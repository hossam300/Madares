using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebForms.Business.Inventory.Models
{
    public class ProductCategory:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
    }
}