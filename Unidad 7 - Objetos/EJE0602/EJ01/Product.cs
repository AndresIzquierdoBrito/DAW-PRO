using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    internal class Product
    {
        private string Name { get; set; }

        private decimal Price { get; set; }


        public Product(string name, decimal price)
        {
            SetName(name);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Product name cannot be null or empty");
            this.Name = name;
        }

        public string GetName() => Name;

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Product price cannot be negative");
            this.Price = price;
        }

        public decimal GetPrice() => Price;

        public override string ToString() => $"{Name, -10}{Price:f2}$";

    }

}

