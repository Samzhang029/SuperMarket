using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    class Promotion3For2 : Promotion
    {
        public Smallware PromotionGoods {get; set;}

        public Promotion3For2(Smallware goods)
        {
            Name = SuperMarketConsts.PromotionName3For2;
            Goods = goods;
            PromotionGoods = goods;

            DoPromotioin();
        }
        
        public override void DoPromotioin()
        {
            int count = PromotionGoods.Count;
            GiftCount = count / 3;

            SavedMoney = GiftCount * PromotionGoods.UnitPrice;
            TotalAfterPromotion = PromotionGoods.Total - SavedMoney;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
