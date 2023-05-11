using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    internal abstract class Transaction
    {
        public decimal GetMoneyIntroduced() => moneyIntroduced;

        public void SetMoneyIntroduced(decimal moneyIntroduced)
        {
            this.moneyIntroduced = moneyIntroduced;
        }

        public bool IsSalePossible()
        {
            if(selectedProducts.Count > 0)
                totalSale += selectedProducts.Last().GetPrice();
            return true;
        }

        
    }
}
