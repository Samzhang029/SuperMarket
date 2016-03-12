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
                        Promotion oneProductPromotion = null;
                        List<PromotionType> allPromotions = strategy.GetPromotions(barCode);
                        if (null != allPromotions)
                        {
                            oneProduct.HasPromotion = true;
                            oneProductPromotion = DealWithPromotions(oneProduct, allPromotions[0]);
                        }
                        cart.AllProducts.Add(oneProduct);
                        if (null != oneProductPromotion)
                        {
                            cart.AllPromotion.Add(barCode, oneProductPromotion);
                        }
                    }
                }
            }
        }

        public static Promotion DealWithPromotions(Smallware oneProduct, PromotionType promotion)
        {
            Promotion currentPromotion;
            switch (promotion)
            { 
                case PromotionType.Buy3For2:
                currentPromotion = new Promotion3For2(oneProduct);
                return (Promotion3For2)currentPromotion;
                break;

            case PromotionType.Discount95:
                currentPromotion = new PromotionDiscount(oneProduct, 0.95m);
                return (PromotionDiscount)currentPromotion;
                break;

            }

            return null;
        }

        internal static string ReadProductsFromJson(string fileName)
        {
            return new StreamReader(@"..\..\Data\" + fileName).ReadToEnd();
        }
    }
}
