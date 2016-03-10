using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    
    public class Smallware
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public string UnitName { get; set; }

        public int Count { get; set; }
                
        public decimal UnitPrice { get; set; }

        public decimal Total {
            get {
                return UnitPrice * Count;       
            }
        }

        public string BarCode { get; set; }

    }

    public enum Category { Food, Goods }
}
