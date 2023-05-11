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
            decimal initialBalance;
            List<Product> purchaseList = new List<Product>();

            Console.WriteLine("Introduce the amount of money for purchase.");
            initialBalance = Utils.DoubleValue(lowerLimit: 0.01m, maxDecimalPlaces: 2);
            do
            {
                Console.WriteLine("Choose one of the following products to purchase, press (0) if you want to finish the transaction:");
                ShowStock();
                Console.Write("\n\nChoose an option");
                option = Utils.IntValue(lowerLimit: 0, upperLimit: totalAmount);

                if (option != 0)
                {
                    if (Transaction.IsSalePossible(purchaseList, initialBalance))
                    {
                        if (Lines[option - 1].GetStock() > 0)
                        {
                            Lines[option - 1].RemoveOneStock();
                            purchaseList.Add(Lines[option - 1].GetProduct());
                            Console.WriteLine($"{Lines[option - 1].GetProduct().GetName()} added to purchase list.");
                        }
                        else Console.WriteLine("There is no stock left for the product selected.\n\nPlease select another of finish the transaction.");
                    }
                    else Console.WriteLine("You currently don't have enough balance to make that purchase\n\nSelect another product or finish transaction.");
                }
                else Console.WriteLine("Transaction finished. Continue to see details...");
                Utils.EndMethod();
            } while (option != 0);

            Transaction.FinishTransaction(purchaseList, initialBalance);

        }

        public void ShowStock()
        {
            int totalAmount = Lines.Count;
            for (int i = 0; i < totalAmount; i++)
            {
                if (i % 4 == 0)
                    Console.WriteLine();
                Console.Write($"({i + 1}) {Lines[i]}\t");
            }
        }

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
