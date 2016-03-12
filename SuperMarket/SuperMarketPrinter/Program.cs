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
        public static ShoppingCart Cart;
        public static PromotionStrategy promotionStrategy; 
        static void Main(string[] args)
        {
            Cart = new ShoppingCart();
            promotionStrategy = new PromotionStrategy();

            InitializeCatalogue();
            InitializePromotionStrategy();

            string oneOrder = SuperMarketHelper.ReadProductsFromJson("input001.json");
            
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);


        }

        private static void InitializePromotionStrategy()
        {
            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Buy3For2); //可口可乐买三送一
            promotionStrategy.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折

        }

        

        private static void InitializeCatalogue()
        {
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000001", Name = "可口可乐", Category = Category.Food, UnitName = "瓶", UnitPrice = 3.00m });
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000003", Name = "羽毛球", Category = Category.Goods, UnitName = "个", UnitPrice = 1.00m });
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000005", Name = "苹果", Category = Category.Food, UnitName = "斤", UnitPrice = 5.50m });
            //...

            
        }


    }
}
