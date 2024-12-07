using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CreateAProductClass
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product() 
        {
            Name = "";
            Price = 0;
            Quantity = 0;
        }

        public Product(string name, decimal price, int quantity)
        {
            Name = name; 
            Price = price; 
            Quantity = quantity;
        }

        public decimal CalculateTotalCost()
        { 
            return Price * Quantity;
        }
    }
}
