using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EJ02
{
    public class VendingMachine
    {
        private Stock stock = new();

        private static decimal amountedSale;

        private static List<int> selectedItems = new();
        public void RefillProduct()
        {
            int totalAmount = stock.amount.Count;
            for (int i = 0; i < totalAmount; i++)
                stock.amount[i] = 10;
            Console.WriteLine("Succesfully refilled the vending machine.");
        }

        public void ExtractProduct()
        {
            int count = 0, option;
            Console.WriteLine("Choose one of the following products to purchase: ");
            stock.products.ForEach(product => {
                if (count % 4 == 0)
                    Console.WriteLine();
                Console.Write($"[{count + 1:00}]  {product}  ");

                count++;
            });

            bool IsSalePossible = true;
            Console.Write("Select option ");
            do
            {
                option = Functions.IntValue(lowerLimit: 1, upperLimit: stock.products.Count);
                if(stock.amount[option - 1] == 0)
                    IsSalePossible = false;
            } while (!IsSalePossible);

            stock.amount[option - 1]--;
            amountedSale += stock.products[option - 1].GetPrice();
            selectedItems.Add(option - 1);
        }

        public void ShowStock()
        {
            int totalAmount = stock.amount.Count;
            for (int i = 0; i < totalAmount; i++)
            {
                if (i % 4 == 0)
                    Console.WriteLine();
                Console.Write($"{stock.products[i].GetName()}{new string(' ', 16 - stock.products[i].GetName().Length)} {stock.amount[i]}{new string(' ', 8 - stock.amount[i].ToString().Length)}");
            }
        }

        public void CompleteTransaction(decimal funds)
        {
            Console.WriteLine("Items selected: ");
            foreach (int i in selectedItems.Distinct())
                Console.WriteLine($"{stock.products[i].GetName()} ({selectedItems.FindAll(p => p.Equals(i)).Count}): {selectedItems.FindAll(p => p.Equals(i)).Count * stock.products[i].GetPrice():f2}$");
            if (funds == 0)
                Console.WriteLine("No balance introduced.");
            else if (funds > amountedSale)
                Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nAmount to be returned: {funds - amountedSale:f2}$");
            else
                Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nNot enough balance. Missing: {amountedSale - funds:f2}$");
        }
    }
}
