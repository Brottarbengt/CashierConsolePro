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
        public decimal Price => CalculatePrice();
        public decimal ListPrice { get; set; }
        public PriceType PriceType { get; }
        public List<Campaign> Campaigns { get; }


        public Product(string name, string productCode, decimal listPrice, PriceType priceType)
        {
            Name = name;
            ProductCode = productCode;
            ListPrice = listPrice;
            PriceType = priceType;
        }

        public override string ToString()
        {
            return $"Product: {Name}, Code: {ProductCode}, Price: {ListPrice:C} Discount: {ListPrice - Price:C}";
        }

        private decimal CalculatePrice()
        {
            decimal price = ListPrice;
            foreach (var campaign in Campaigns)
            {
                price = price * ( 1 - (campaign.Discount / 100));
            }
            return price;
        }
        
    }


    public enum PriceType
    {
        Weight,
        PerEach
    }
    
}
