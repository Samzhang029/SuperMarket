using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public class ShoppingCartPrinter
    {
        public ShoppingCart shoppingCart;

        public ShoppingCartPrinter(ShoppingCart _cart)
        {
            shoppingCart = _cart; 
        }

        public string PrintShoppingCart()
        {
            StringBuilder sbShoppingList = new StringBuilder();
            bool hasAdditionalInfo = false;
            StringBuilder sbBuy3Fro2 = new StringBuilder();

            try
            {
                sbShoppingList.Append(PrintSuperMaketTitle());
                foreach (var item in shoppingCart.AllProducts)
                {
                    if (!item.HasPromotion)
                    {
                        sbShoppingList.Append(item.ToString());
                    }
                    else
                    {
                        Promotion currentPromotion = shoppingCart.AllPromotion[item.BarCode];
                        if (currentPromotion.Name.Equals(PromotionType.Buy3For2))
                        {
                            if (!hasAdditionalInfo)
                            {
                                hasAdditionalInfo = true;
                            }
                            sbBuy3Fro2.Append(((Promotion3For2)currentPromotion).PrintPromotion3For2());
                        }
                        sbShoppingList.Append(currentPromotion.ToString());
                    }
                }

                //Print a cutting line.
                sbShoppingList.Append(PrintCuttingLine());

                if (hasAdditionalInfo)
                {
                    sbShoppingList.Append(PrintBuy3For2Title());
                    sbShoppingList.Append(sbBuy3Fro2.ToString());
                    sbShoppingList.Append(PrintCuttingLine());
                }

                //print ShoppingCart info
                sbShoppingList.Append(shoppingCart.ToString());

                //Print a ending line
                sbShoppingList.Append(PrintEndingLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Print error: {0}", ex.Message);
            }

            return sbShoppingList.ToString();
        }
        
        private string PrintSuperMaketTitle()
        {
            return String.Format("***<{0}>购物清单***\r\n", SuperMarketConsts.SuperMarketName);
        }
        private string PrintCuttingLine()
        {
            return "--------------------------\r\n";
        }
        private string PrintEndingLine()
        {
            return "**************************\r\n";
        }
        private string PrintBuy3For2Title()
        {
            return "买二赠一商品：\r\n";
        }

    }
}
