using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public class ShoppingCartPrinter
    {
        public ShoppingCart shopCart;
        public ShoppingCartPrinter(ShoppingCart _cart)
        {
            shopCart = _cart; 
        }

        public string PrintOneNormalItem(Smallware item)
        {
            string strItem = string.Empty;
            strItem = String.Format("名称：{0}，数量：{1}，单价：{2}（元），小计：{3}元\r\n" , 
                                    item.Name, 
                                    item.Count,
                                    item.UnitPrice,
                                    item.Total);

            return strItem;
        }

        public string PrintOnePromotionDiscountItem(Smallware item, ShoppingCart cart)
        {
            return string.Empty;   
        }

        public string PrintOnePromotionBuy3For2Item(Smallware item, ShoppingCart cart)
        {
            return string.Empty;
        }

        public string PrintSuperMaketTitle()
        {
            return String.Format("***<{0}>购物清单***"， SuperMarketConsts.SuperMarketName);
        }
        public string PrintCuttingLine()
        {
            return "-----------------------";
        }
        public string PrintEndingLine()
        {
            return "***********************";
        }

    }
}
