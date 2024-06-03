using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_G1
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productId, string productName, decimal price, int stock)
        {
            if (productId < 1 || productId > 1000)
                throw new ArgumentOutOfRangeException(nameof(productId), "ProductID must be between 1 and 1000.");

            if (price < 1 || price > 5000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be between $1 and $5000.");

            if (stock < 1 || stock > 1000)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be between 1 and 1000.");
            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to increase cannot be negative.", nameof(amount));
            Stock += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to decrease cannot be negative.", nameof(amount));
            if (amount > Stock)
                throw new InvalidOperationException("Amount to decrease exceeds stock available.");

            Stock -= amount;
        }
    }

}
