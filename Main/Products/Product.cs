using CashierConsolePro.CampaignTools;



namespace CashierConsolePro.Products
{
    public class Product
    {
        public string Name { get; private set; }
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
            Campaigns = new List<Campaign>();
        }
        public void SetName(string newName)
        {
            Name = newName;
        }
        public override string ToString()
        {
            return $"Product: {Name}, Code: {ProductCode}, Price: {ListPrice:C} Discount: {ListPrice - Price:C}";
        }

        private decimal CalculatePrice()
        {
            decimal price = ListPrice;
            if (Campaigns !=null)
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
