using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
     
    public class PromotionStrategy
    {
        public Dictionary<string, List<PromotionType>> AllPromotions = new Dictionary<string, List<PromotionType>>();
        
        public void AddNewPromotion(string _barCode, PromotionType _promotion)
        {
            List<PromotionType> promotions;
            if (this.AllPromotions.TryGetValue(_barCode, out promotions))
            {
                this.AllPromotions[_barCode].Add(_promotion);
            }
            else
            {
                this.AllPromotions.Add(_barCode, new List<PromotionType>() {_promotion});
            }
            
        }

        public void DeletePromotion(string _barCodeDeleted)
        {
            this.AllPromotions.Remove(_barCodeDeleted);
        }

        public List<PromotionType> GetPromotions(string _barCode)
        {
            List<PromotionType> allPromotions;
            if (!this.AllPromotions.TryGetValue(_barCode, out allPromotions))
            { 
                //No promotion for this item. 
                return null;
            }
            else
            {
                allPromotions = CalculatePromotions(this.AllPromotions[_barCode]);
            }
            return allPromotions;
        }

        //微调优惠信息。例如，打九五折和买三送一同时有的时候，仅买三送一有效。
        private List<PromotionType> CalculatePromotions(List<PromotionType> listPromtions)
        {
            bool hasBuyForTwo = false;
            bool hasDiscount95 = false;

            foreach (PromotionType type in listPromtions)
            {
                if (type.Equals(PromotionType.Buy3For2))
                    hasBuyForTwo = true;

                if(type.Equals(PromotionType.Discount95))
                    hasDiscount95 = true;
            }
            
            if(hasBuyForTwo && hasDiscount95)
            {
                listPromtions.Remove(PromotionType.Discount95);
            }

            return listPromtions;
        }

    }

    public enum PromotionType
    {
        Discount95,
        Buy3For2,
    }
}
