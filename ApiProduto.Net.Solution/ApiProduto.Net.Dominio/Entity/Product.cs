using System;

namespace ProductApi.Net.Domain.Entity
{
    public class Product
    {
        public Product() { }

        public Product(string name, decimal price, string brand)
        {
            Name = name;
            Price = price;
            Brand = brand;
            UpdateAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
