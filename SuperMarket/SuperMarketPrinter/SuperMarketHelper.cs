using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperMarketPrinter
{
    public static class SuperMarketHelper
    {
        /// <summary>
        /// Put all goods into the ShoppingCart
        /// </summary>
        /// <param name="cart">ShoppingCart for this order</param>
        /// <param name="oneOrder">A Order</param>
        /// <param name="strategy">Pomotion Information</param>
        public static void PutProductsIntoShoppingCart(ShoppingCart cart, string oneOrder, PromotionStrategy strategy)
        {
            JsonReader reader = new JsonTextReader(new StringReader(oneOrder));
            while (reader.Read())
            {
                string oneItem = reader.Value as string;
                string barCode;
                int countProducts =1;
                if (null!=oneItem  && oneItem.IndexOf("ITEM") >= 0)
                {
                    barCode = oneItem;
                    if (oneItem.IndexOf("-") > 0)
                    {
                        barCode = oneItem.Substring(0, oneItem.IndexOf("-")); 
                        Int32.TryParse(oneItem.Substring(oneItem.IndexOf("-")+1) , out countProducts);
                    }

                    //Get the product object from Catalogue
                    Smallware existProduct = cart.GetExistProduct(barCode);
                    if (null != existProduct)
                    { 
                        //Existed item in Cart, please Update the count
                        existProduct.Count += countProducts;

                        //Then update the promotion
                        Promotion existProductPromotion; 
                        if(cart.AllPromotion.TryGetValue(barCode, out existProductPromotion))
                        {
                            existProductPromotion.DoPromotioin();
                        }
                    }
                    else
                    {
                        Smallware oneProduct  = (Catalogue.GetProductByBarCode(barCode) as Smallware).Clone() as Smallware;
                        oneProduct.Count = countProducts;
                        if( null!= strategy)
                        {
                            Promotion oneProductPromotion = null;
                            List<PromotionType> allPromotions = strategy.GetPromotions(barCode);
                            if (null != allPromotions)
                            {
                                oneProduct.HasPromotion = true;
                                oneProductPromotion = DealWithPromotions(oneProduct, allPromotions[0]);
                            }
                        
                            if (null != oneProductPromotion)
                            {
                                cart.AllPromotion.Add(barCode, oneProductPromotion);
                            }
                        }
                        cart.AllProducts.Add(oneProduct);
                    }
                }
            }
        }

        /// <summary>
        /// Create new promotion to one product.
        /// </summary>
        /// <param name="oneProduct"></param>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public static Promotion DealWithPromotions(Smallware oneProduct, PromotionType promotion)
        {
            Promotion currentPromotion;
            switch (promotion)
            { 
                case PromotionType.Buy3For2:
                currentPromotion = new Promotion3For2(oneProduct);
                currentPromotion.Name = PromotionType.Buy3For2;
                return (Promotion3For2)currentPromotion;
                break;

            case PromotionType.Discount95:
                currentPromotion = new PromotionDiscount(oneProduct, 0.95m);
                currentPromotion.Name = PromotionType.Discount95;
                return (PromotionDiscount)currentPromotion;
                break;

            }
            return null;
        }

        public static string ReadProductsFromJson(string fileName)
        {
            return new StreamReader(@"..\..\..\TestData\" + fileName).ReadToEnd();
        }

        public static void InitializeCatalogue()
        {
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000001", Name = "可口可乐", Category = Category.Food, UnitName = "瓶", UnitPrice = 3.00m });
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000003", Name = "羽毛球", Category = Category.Goods, UnitName = "个", UnitPrice = 1.00m });
            Catalogue.AddNewProduct(new Smallware() { BarCode = "ITEM000005", Name = "苹果", Category = Category.Food, UnitName = "斤", UnitPrice = 5.50m });
            //...
        }


        public static void InitializePromotionStrategy(PromotionStrategy promotionStrategy)
        {
            promotionStrategy.AddNewPromotion("ITEM000001", PromotionType.Buy3For2); //可口可乐买二送一
            promotionStrategy.AddNewPromotion("ITEM000003", PromotionType.Buy3For2); //羽毛球买二送一
            promotionStrategy.AddNewPromotion("ITEM000005", PromotionType.Discount95); //苹果95折
        }

    }
}
