using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    public abstract class Promotion
    {
        public string Name { get; set; }

        public Smallware Goods{get; set;}

        public decimal DiscountPrice { get; set; }

        public decimal TotalAfterPromotion { get; set; }
        
        public decimal SavedMoney { get; set; }

        public int GiftCount { get; set; }

        public abstract void DoPromotioin();

        public abstract override string ToString();
    }

    
}


