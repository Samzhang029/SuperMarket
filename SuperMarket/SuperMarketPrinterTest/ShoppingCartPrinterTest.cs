using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarketPrinter;

namespace SuperMarketPrinterTest
{
    [TestClass]
    public class ShoppingCartPrinterTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SuperMarketHelper.InitializeCatalogue();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Catalogue.AllProducts.Clear();
        }

        /// <summary>
        /// 测试全部商品无促销
        /// </summary>
        [TestMethod]
        public void NormalGoodsTest()
        {
            ShoppingCart Cart = new ShoppingCart();
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("NormalGoodsTest.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, null); //No any promotion.
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);

            string expectedResults = ReadExpectedResults("NormalGoodsTestResults.txt");
            Assert.AreEqual(expectedResults, shoppingPrinter.PrintShoppingCart());
        }

        /// <summary>
        /// 测试有商品打95折
        /// </summary>
        [TestMethod]
        public void PromotionDiscount95Test()
        {
            ShoppingCart Cart = new ShoppingCart();
            PromotionStrategy promotionStrategy = new PromotionStrategy();

            promotionStrategy.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("PromotionDiscount95Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);

            string expectedResults = ReadExpectedResults("PromotionDiscount95TestResults.txt");
            Assert.AreEqual(expectedResults, shoppingPrinter.PrintShoppingCart());
        }

        /// <summary>
        /// 测试有商品买二送一
        /// </summary>
        [TestMethod]
        public void PromotionBuy3For2Test()
        {
            ShoppingCart Cart = new ShoppingCart();
            PromotionStrategy promotionStrategy = new PromotionStrategy();

            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Buy3For2); //可口可乐买2送一
            promotionStrategy.AddNewPromotion("ITEM000003", PromotionType.Buy3For2); //羽毛球买2送一
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("PromotionBuy3For2Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);
            
            string expectedResults = ReadExpectedResults("PromotionBuy3For2TestResults.txt");
            Assert.AreEqual(expectedResults, shoppingPrinter.PrintShoppingCart());
        }

        /// <summary>
        /// 测试有的商品买二送一，有的商品是打95折。
        /// </summary>
        [TestMethod]
        public void PromotionDiscount95AndBuy3For2Test()
        {
            ShoppingCart Cart = new ShoppingCart();
            PromotionStrategy promotionStrategy = new PromotionStrategy();

            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Buy3For2); //可口可乐买2送一
            promotionStrategy.AddNewPromotion("ITEM000003", PromotionType.Buy3For2); //羽毛球买2送一
            promotionStrategy.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("PromotionDiscount95AndBuy3For2Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);
            
            string expectedResults = ReadExpectedResults("PromotionDiscount95AndBuy3For2TestResults.txt");
            Assert.AreEqual(expectedResults, shoppingPrinter.PrintShoppingCart());
        }

        /// <summary>
        /// 测试同一个商品有叠加促销的情况，同时打95折 and 买二送一，仅买二送一生效。
        /// 测试数据同PromotionDiscount95AndBuy3For2Test一样，仅促销策略不同。
        /// </summary>
        [TestMethod]
        public void PromotionOneItemDiscount95AndBuy3For2Test()
        {
            ShoppingCart Cart = new ShoppingCart();
            PromotionStrategy promotionStrategy = new PromotionStrategy();

            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Discount95); //可口可乐95折
            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Buy3For2); //可口可乐买二送一
            promotionStrategy.AddNewPromotion("ITEM000003", PromotionType.Discount95); //羽毛球95折
            promotionStrategy.AddNewPromotion("ITEM000003", PromotionType.Buy3For2); //羽毛球买2送一            
            promotionStrategy.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折
            string oneOrder = SuperMarketHelper.ReadProductsFromJson("PromotionDiscount95AndBuy3For2Test.json");
            SuperMarketHelper.PutProductsIntoShoppingCart(Cart, oneOrder, promotionStrategy);
            ShoppingCartPrinter shoppingPrinter = new ShoppingCartPrinter(Cart);

            string expectedResults = ReadExpectedResults("PromotionDiscount95AndBuy3For2TestResults.txt");
            Assert.AreEqual(expectedResults, shoppingPrinter.PrintShoppingCart());
        }
               

        private string ReadExpectedResults(string fileName)
        {
            string results = string.Empty;

            if (File.Exists(@"..\..\..\TestData\" + fileName))
            {
                results =  new StreamReader(@"..\..\..\TestData\" + fileName).ReadToEnd();
            }
            return results;
        }
    }
}
