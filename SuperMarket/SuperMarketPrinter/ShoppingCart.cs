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

        public ShoppingCart()
        {
            allProducts = new List<Smallware>();
        }
        
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal TotalOfShoppingCart 
        {
            get
            {
                decimal totalValue = 0.00m;
                foreach (Smallware product in allProducts)
                {
                    if (!product.HasPromotion)
                    {
                        totalValue += product.Total;
                    }
                    else
                    {
                        Promotion promotionItem = AllPromotion[product.BarCode];
                        totalValue += promotionItem.TotalAfterPromotion;
                    }
                }

                return totalValue;
            }
        }

        /// <summary>
        /// 总优惠
        /// </summary>
        public decimal TotalOfDiscount
        {
            get
            {
                decimal totalSaveMoney = 0.00m;
                foreach (var pItem in AllPromotion)
                {
                    Promotion promotionItem = pItem.Value;
                    totalSaveMoney += promotionItem.SavedMoney;                
                }

                return totalSaveMoney;
            }
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

        //Get all products which has promotion.
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

        /// <summary>
        /// Print the information of ShoppingCart
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string strCart = string.Empty;
            strCart += String.Format("总计：{0}（元）\r\n",
                                    this.TotalOfShoppingCart
                                    );
            if (this.TotalOfDiscount > 0.00m)
            {
                strCart += String.Format("节省：{0}（元）\r\n",
                                    this.TotalOfDiscount
                                    );
            }
            return strCart; 
        }
    }
}
