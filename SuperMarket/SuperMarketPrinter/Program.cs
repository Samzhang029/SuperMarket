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
        static void Main(string[] args)
        {
            Cart = new ShoppingCart();
            InitializeCatalogue();
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("input001.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder);


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
