using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    class PromotionDiscount : Promotion
    {
        public PromotionDiscount(Smallware goods, decimal _discount)
        {
            Name = PromotionType.Discount95;
            Goods = goods;
            Discount = _discount;
            DoPromotioin();
        }
        
        public decimal Discount { get; set; }

        public override void DoPromotioin()
        {            
            decimal currentPrice = Goods.UnitPrice;
            DiscountPrice = currentPrice * Discount;

            TotalAfterPromotion = Math.Round(DiscountPrice * Goods.Count, 2);
            SavedMoney = Math.Round(Goods.Total - TotalAfterPromotion, 2);
        }

        public override string ToString()
        {
            string strItem = string.Empty;
            strItem = String.Format("名称：{0}，数量：{1}，单价：{2}（元），小计：{3}（元），节省：{4}（元）\r\n",
                                    Goods.Name,
                                    Goods.Count + Goods.UnitName,
                                    Goods.UnitPrice,
                                    TotalAfterPromotion,
                                    SavedMoney);

            return strItem;
        }
    }
}
