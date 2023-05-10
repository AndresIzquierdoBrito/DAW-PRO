using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    internal class Transaction
    {
        private decimal moneyIntroduced { get; set; }

        private decimal totalSale;

        public List<Product> selectedProducts = new();

        public Transaction(decimal moneyIntroduced)
        {
            SetMoneyIntroduced(moneyIntroduced);
        }

        public decimal GetMoneyIntroduced() => moneyIntroduced;

        public void SetMoneyIntroduced(decimal moneyIntroduced)
        {
            this.moneyIntroduced = moneyIntroduced;
        }

        public bool IsSalePossible()
        {
            if(selectedProducts.Count > 0)
                totalSale += selectedProducts.Last().GetPrice();
            Console.WriteLine(totalSale);
            return true;
        }
    }
}
