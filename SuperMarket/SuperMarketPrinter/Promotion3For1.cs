using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPrinter
{
    class Promotion3For1 : Promotion
    {
        private Smallware promotionGoods;
        public Promotion3For1(Smallware goods)
        {
            promotionGoods = goods;
        }
        
        public override void DoPromotioin()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
