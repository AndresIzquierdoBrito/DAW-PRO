using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Stock
    {
        public List<Product> products = new()
        {
            new Product ("Doritos", 2.3m),
            new Product("Snickers Bar", 1.5m),
            new Product("Coca-Cola", 2.0m),
            new Product("Pringles", 2.5m),
            new Product("Skittles", 1.25m),
            new Product("Red Bull", 3.5m),
            new Product("Kit-Kat", 1.75m),
            new Product("Gatorade", 2.5m),
            new Product("M&M's", 1.25m),
            new Product("Fritos", 2.0m),
            new Product("Pepsi", 2.0m),
            new Product("Cheez-It", 2.5m),
            new Product("Twix", 1.75m),
            new Product("Powerade", 2.5m),
            new Product("Ruffles", 2.5m),
            new Product("Hershey's Bar", 1.5m),
            new Product("Diet Coke", 2.0m),
            new Product("Oreos", 2.5m),
            new Product("Monster Energy", 3.5m),
            new Product("Cheetos", 2.0m)
        };

        public List<int> amount = new();

        public Stock()
        {
            for (int i = 0; i < 20; i++)
                amount.Add(10);
        }

    }
}
