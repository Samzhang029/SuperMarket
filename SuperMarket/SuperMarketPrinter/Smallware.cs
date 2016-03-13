using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    
    public class Smallware : ICloneable
    {
        #region Properties
        public string Name { get; set; }

        public Category Category { get; set; }

        public string UnitName { get; set; } //个，斤，瓶

        public int Count { get; set; }
                
        public decimal UnitPrice { get; set; }

        public decimal Total {
            get 
            {
                return UnitPrice * Count;       
            }
        }

        public string BarCode { get; set; }

        public bool HasPromotion { get; set; }
        #endregion

        public string ToString()
        {
            string strItem = string.Empty;
            strItem = String.Format("名称：{0}，数量：{1}，单价：{2}（元），小计：{3}（元）\r\n",
                                    this.Name,
                                    this.Count + this.UnitName,
                                    this.UnitPrice,
                                    this.Total);

            return strItem;
        }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public enum Category { Food, Goods }
}
