using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public static class Catalogue
    {
        public static Dictionary<string, Smallware> AllProducts = new Dictionary<string, Smallware>();
        
        public static void AddNewProduct(Smallware product)
        {
            AllProducts.Add(product.BarCode, product);
        }

        public static void DeleteProduct(Smallware product)
        {
            AllProducts.Remove(product.BarCode);
        }
    }
}
