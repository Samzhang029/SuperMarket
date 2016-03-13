using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SuperMarketPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperMarketHelper.InitializeCatalogue();

            ShoppingCart Cart = new ShoppingCart();
            PromotionStrategy promotionStrategy = new PromotionStrategy();            
            SuperMarketHelper.InitializePromotionStrategy(promotionStrategy);
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("PromotionDiscount95AndBuy3For2Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);
            Console.WriteLine(shoppingPrinter.PrintShoppingCart());

            ShoppingCart Cart2 = new ShoppingCart();
            PromotionStrategy promotionStrategy2 = new PromotionStrategy();
            promotionStrategy2.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折
            string oneOrder2 = SuperMarketHelper.ReadProductsFromJson("PromotionDiscount95Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart2, oneOrder2, promotionStrategy2);
            ShoppingCartPrinter shoppingPrinter2 = new ShoppingCartPrinter(Cart2);
            Console.WriteLine(shoppingPrinter2.PrintShoppingCart());

            Console.ReadLine();
        }
    }
}
