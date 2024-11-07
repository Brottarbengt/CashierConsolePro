using CashierConsolePro.FileManagement;

namespace CashierConsolePro.Products
{
    public class ProductStore : IFileReader, IFileWriter
    {

        private static ProductStore instance;
        private List<Product> products = new List<Product>();
        
        private readonly string filePath = "./products.txt"; // File to store products.

        private ProductStore()
        {

        }
        
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
        

        
        public void Write()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.ProductCode}," +
                        $"{product.Price},{product.PriceType}");
                }

            }
        }

        
        public void Read()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    products.Clear();
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        if (data.Length == 4)
                        {
                            string name = data[0];
                            string productCode = data[1];
                            PriceType priceType = Enum.Parse<PriceType>(data[3]);
                            if (decimal.TryParse(data[2], out decimal price))
                            {
                                products.Add(new Product(name, productCode, price, priceType));
                            }

                        }
                    }
                }
            }
        }

        public Product? FindProduct(string productCode)
        {
            foreach (var product in products)
            {
                if (productCode.Equals(product.ProductCode, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }
        
        public List<Product> GetAllProducts()
        {
            return products;
        }

        public static ProductStore Instance()
        {
            if (instance == null)
            {
                instance = new ProductStore();
            }
            return instance;
        }
        public bool IsProductUnique(string name, string productCode)
        {
            return !products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                                      p.ProductCode.Equals(productCode, StringComparison.OrdinalIgnoreCase));
        }

    }
}

