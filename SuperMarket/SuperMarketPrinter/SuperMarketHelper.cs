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

        public static void PutProductsIntoShoppingCart(ShoppingCart cart, string oneOrder)
        {
            JsonReader reader = new JsonTextReader(new StringReader(oneOrder));
            while (reader.Read())
            {
                string oneItem = reader.Value as string;
                string barCode;
                int countProducts =1;
                if (oneItem.IndexOf("ITEM") >= 0)
                {
                    barCode = oneItem;
                    if (oneItem.IndexOf("-") > 0)
                    {
                        barCode = oneItem.Substring(0, oneItem.IndexOf("-")); 
                        Int32.TryParse(oneItem.Substring(oneItem.IndexOf("-")+1) , out countProducts);
                    }

                    //Get the product object from Catalogue
                    //if(cart.)
                    Smallware oneProduct  = (Catalogue.SearchProductByBarCode(barCode) as Smallware).Clone();
                    oneProduct.Count = countProducts;
                }
            }
        }

        internal static string ReadProductsFromJson(string fileName)
        {
            return new StreamReader(@"..\..\Data\" + fileName).ReadToEnd();
        }
    }
}
