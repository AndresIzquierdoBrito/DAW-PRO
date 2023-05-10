using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EJ01
{
    public class VendingMachine
    {
        private List<Line> Lines = new();

        private int MaxAmountLines { get; set; }

        private int MaxDepth { get; set; }

        private static decimal amountedSale;

        private int GetMaxStockerPerLine() => this.MaxDepth;

        private void SetMaxStockPerLine(int maxStock)
        {
            if (maxStock < 0)
                throw new ArgumentOutOfRangeException(nameof(maxStock), "Maximum product stock per line cannot be negative");
            this.MaxDepth = maxStock;
        }

        private int GetAmountLines() => this.MaxAmountLines;


        private void SetAmountLines(int amountLines)
        {
            if (amountLines < 0)
                throw new ArgumentOutOfRangeException(nameof(amountLines), "The vending machine cannot have negative lines");
            this.MaxAmountLines = amountLines;
        }

        public VendingMachine(int maxStock, int amountLines)
        {
            SetAmountLines(amountLines);
            SetMaxStockPerLine(maxStock);
        }
        public void AddProduct()
        {
            if (Lines.Count < MaxAmountLines)
            {
                Console.WriteLine($"Introduce the new product's name, price and its initial stock. \n(CURRENT MAXIMUM STOCK PER LINE: {MaxDepth} | LINES REMAINING IN VENDING MACHINE: {MaxAmountLines - Lines.Count}");
                string productName = Utils.ValidProductName();
                decimal productPrice = Utils.DoubleValue(lowerLimit: 0, maxDecimalPlaces: 2);
                int initialStock = Utils.IntValue(lowerLimit: 1, upperLimit: MaxDepth);

                Lines.Add(new Line(productName, productPrice, initialStock, MaxDepth));
            }
            else
                Console.WriteLine("Vending machine is at capacity. Remove a product if you wish you add a new one.");
        }

        public void RemoveProduct()
        {
            int totalAmount = Lines.Count, option;
            Console.WriteLine("Choose one of the following products to remove: ");
            for (int i = 0; i < totalAmount; i++)
            {
                if (i % 3 == 0)
                    Console.WriteLine();
                Console.Write($"({i+1}) {Lines[i]}\t");
            }
            option = Utils.IntValue(1, totalAmount);
            Lines.RemoveAt(option - 1);
        }
        public void RefillAllProducts()
        {
            Lines.ForEach(product => product.SetStock(MaxDepth));
            Console.WriteLine("Succesfully refilled the vending machine.");
        }

        public void ExtractProduct()
        {

            int totalAmount = Lines.Count, option;
            
            Transaction transaction = new(10);
            do
            {
                Console.WriteLine("Choose one of the following products to purchase, press (0) if you want to finish the transaction:");
                for (int i = 0; i < totalAmount; i++)
                {
                    if (i % 3 == 0)
                        Console.WriteLine();
                    Console.Write($"({i + 1:00}) {Lines[i]}\t");
                }
                Console.Write("\n\nChoose an option");
                option = Utils.IntValue(lowerLimit: 0, upperLimit: totalAmount);
                if (option != 0 && Lines[option - 1].GetStock() > 0 && transaction.IsSalePossible())
                {
                    Lines[option - 1].RemoveOneStock();
                    transaction.selectedProducts.Add(Lines[option - 1].GetProduct());
                }
                Console.ReadKey();
                Console.Clear();
            } while (option != 0);

            Console.WriteLine(transaction.IsSalePossible);
        }

        public void ShowStock()
        {
            int totalAmount = Lines.Count;
            for (int i = 0; i < totalAmount; i++)
            {
                if (i % 4 == 0)
                    Console.WriteLine();
                Console.Write($"{Lines[i]}\t");
            }
        }

        //public void CompleteTransaction(decimal funds)
        //{
        //    Console.WriteLine("Items selected: ");
        //    foreach (int i in selectedItems.Distinct())
        //        Console.WriteLine($"{stock.products[i].GetName()} ({selectedItems.FindAll(p => p.Equals(i)).Count}): {selectedItems.FindAll(p => p.Equals(i)).Count * stock.products[i].GetPrice():f2}$");
        //    if (funds == 0)
        //        Console.WriteLine("No balance introduced.");
        //    else if (funds > amountedSale)
        //        Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nAmount to be returned: {funds - amountedSale:f2}$");
        //    else
        //        Console.WriteLine($"\nTotal cost of items selected: {amountedSale}$\nNot enough balance. Missing: {amountedSale - funds:f2}$");
        //}
        public void GenerateVendingMachineStock()
        {
            Lines = new List<Line>
            {
                new Line("Doritos", 2.3m, 4, MaxDepth),
                new Line("CocaCola", 1.5m, 3, MaxDepth),
                new Line("Lays", 2.2m, 6, MaxDepth),
                new Line("Pepsi", 1.6m, 10, MaxDepth),
                new Line("KitKat", 1.8m, 10, MaxDepth),
                new Line("Sprite", 1.5m, 10, MaxDepth),
                new Line("Twix", 1.9m, 10, MaxDepth),
                new Line("Fanta", 1.5m, 10, MaxDepth),
                new Line("Snickers", 2.1m, 10, MaxDepth)
            };

        }

    }
}
