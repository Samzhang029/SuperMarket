using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public class ShoppingCart
    {
        public List<Smallware> NormalProducts { get; set; }

        public List<Promotion> PromotionProducts { get; set; }
    }
}
