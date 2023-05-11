using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    internal class Transaction
    {
        public static bool IsSalePossible(List<Product> productList, decimal balance)
        {
            if (productList.Sum(x => x.GetPrice()) > balance)
                return false;
            else
                return true;
        }

        public static void FinishTransaction(List<Product> productList, decimal balance)
        {

        }

        public void CompleteTransaction(decimal funds)
        {
            Console.WriteLine("Items selected: ");
            foreach (int i in selectedItems.Distinct())
                Console.WriteLine($"{stock.products[i].GetName()} ({selectedItems.FindAll(p => p.Equals(i)).Count}): {selectedItems.FindAll(p => p.Equals(i)).Count * stock.products[i].GetPrice():f2}$");
            if (funds == 0)
                Console.WriteLine("No initialBalance introduced.");
            else if (funds > amountedSale)
                Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nAmount to be returned: {funds - amountedSale:f2}$");
            else
                Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nNot enough initialBalance. Missing: {amountedSale - funds:f2}$");
        }
    }
}
