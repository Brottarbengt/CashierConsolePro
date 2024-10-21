using Kassan.CampaignTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Products
{
    public class Product
    {
        public string Name { get; }
        public string ProductCode { get; }
        public decimal Price { get; }
        public PriceType PriceType { get; }
        public Campaign[] Campaigns { get;}

        public Product(string name, string productCode, decimal price, PriceType priceType)
        {
            Name = name;
            ProductCode = productCode;
            Price = price;
            PriceType = priceType;
        }

        public override string ToString()
        {
            return $"Product: {Name}, Code: {ProductCode}, Price: {Price:C}";
        }
    }

    public enum PriceType
    {
        Weight,
        PerEach
    }
    
}
