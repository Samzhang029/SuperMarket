using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    class PromotionDiscount : Promotion
    {
        private Smallware promotionGoods;
        public PromotionDiscount(Smallware goods, decimal _discount)
        {
            Goods = goods;
            promotionGoods = goods;
            Discount = _discount;

            DoPromotioin();
        }
        
        public decimal Discount { get; set; }

        public override void DoPromotioin()
        {            
            decimal currentPrice = this.promotionGoods.UnitPrice;
            DiscountPrice = currentPrice * Discount;

            TotalAfterPromotion = DiscountPrice * promotionGoods.Count;
            SavedMoney = promotionGoods.Total - TotalAfterPromotion;
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
