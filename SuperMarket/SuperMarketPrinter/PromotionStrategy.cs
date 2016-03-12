using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
     
    public class PromotionStrategy
    {
        public Dictionary<string, PromotionType> AllPromotions = new Dictionary<string, PromotionType>();
        
        public void AddNewPromotion(string _barCode, PromotionType _promotion)
        {
            this.AllPromotions.Add(_barCode, _promotion);
        }

        public void DeletePromotion(string _barCodeDeleted)
        {
            this.AllPromotions.Remove(_barCodeDeleted);
        }

        public PromotionType GetPromotion(string _barCode)
        {
            return this.AllPromotions[_barCode];
        }

    }

    public enum PromotionType
    {
        Discount,
        Buy3For2,
    }
}
