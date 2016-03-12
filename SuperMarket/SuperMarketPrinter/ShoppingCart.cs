using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public class ShoppingCart
    {
        public List<Smallware> allProducts;

        public decimal TotalOfShoppingCart {get; set;};
        public decimal TotalOfDiscount {get; set;}

        public ShoppingCart()
        {
            allProducts = new List<Smallware>();
        }

        public List<Smallware> AllProducts {

            get
            {
                return this.allProducts;
            }
            set
            {
                allProducts = value;
            }
        
        }

        //Save all promotion information.
        public Dictionary<string, Promotion> AllPromotion = new Dictionary<string, Promotion>();

        public Smallware GetExistProduct(string BarCode)
        {
            if (null != AllProducts)
            {
                foreach (Smallware product in AllProducts)
                {
                    if (BarCode == product.BarCode)
                    {
                        return product;
                    }
                }
            }
            return null;
        }

        public List<Smallware> GetPromotionProducts() 
        {
            List<Smallware> promotionProducts = new List<Smallware>();

            foreach (Smallware product in this.AllProducts)
            {
                if (product.HasPromotion)
                {
                    promotionProducts.Add(product);
                }
            }

            return promotionProducts;
        }
        
    }
}
