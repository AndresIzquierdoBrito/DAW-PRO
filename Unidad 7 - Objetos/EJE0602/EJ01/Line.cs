using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EJ01
{
    internal class Line
    {
        private Product Product { get; set; }

        private int Stock { get; set; }

        private readonly int Depth;

        public Line(string productName, decimal productPrice, int initialStock, int machineDepth)
        {
            Depth = machineDepth;
            SetProduct(productName, productPrice);
            SetStock(initialStock);
        }

        public Product GetProduct() => this.Product;

        public void SetProduct(string productName, decimal productPrice)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentNullException(nameof(productName), "Product name cannot be null or empty");
            if (productPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(productPrice), "Product price cannot be negative");
            this.Product = new(productName, productPrice);
        }

        public int GetStock() => this.Stock;

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock), "Product stock cannot be negative");
            if (stock > Depth)
                throw new ArgumentOutOfRangeException(nameof(stock), "Product stock cannot be higher than " + Depth);
            this.Stock = stock;
        }

        public void RemoveOneStock() => SetStock(Stock - 1);
        public override string ToString() => $"{Product, -10} [{Stock:00}]";
    }
}
