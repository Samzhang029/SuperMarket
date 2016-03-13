using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    class Promotion3For2 : Promotion
    {
        //public Smallware PromotionGoods {get; set;}

        public Promotion3For2(Smallware goods)
        {
            Name = PromotionType.Buy3For2;
            Goods = goods;
            //PromotionGoods = goods;

            DoPromotioin();
        }
        
        public override void DoPromotioin()
        {
            int count = Goods.Count;
            GiftCount = count / 3;

            SavedMoney = Math.Round(GiftCount * Goods.UnitPrice, 2);
            TotalAfterPromotion = Math.Round(Goods.Total - SavedMoney, 2);
        }

        public string PrintPromotion3For2()
        {
            string strPromotion = string.Empty;
            strPromotion = String.Format("名称：{0}，数量：{1}\r\n",
                                    Goods.Name,
                                    GiftCount + Goods.UnitName);

            return strPromotion;
        }

        public override string ToString()
        {
            string strItem = string.Empty;
            strItem = String.Format("名称：{0}，数量：{1}，单价：{2}（元），小计：{3}（元）\r\n",
                                    Goods.Name,
                                    Goods.Count + Goods.UnitName,
                                    Goods.UnitPrice,
                                    TotalAfterPromotion);

            return strItem;
        }
    }
}
