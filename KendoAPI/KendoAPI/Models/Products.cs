using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoAPI.Models
{
    public class Products
    {
        public string ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int UnitPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Instructions { get; set; }
        public string Path { get; set; }
        //public string Id { get; set; }
        //public string F10400 { get; set; }
        //public string F10401 { get;set; }
    }
}