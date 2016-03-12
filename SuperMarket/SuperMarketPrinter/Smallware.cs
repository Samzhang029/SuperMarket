using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    
    public class Smallware : ICloneable
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

        public bool HasPromotion { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public enum Category { Food, Goods }
}
