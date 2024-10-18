using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Products
{
    public class Product
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string productCode, decimal price)
        {
            Name = name;
            ProductCode = productCode;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product: {Name}, Code: {ProductCode}, Price: {Price:C}";
        }
    }
}
