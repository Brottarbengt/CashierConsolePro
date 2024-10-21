using Kassan.CampaignTools;
using Kassan.CampaignTools.Kassan.CampaignTools;
using Kassan.FileManagement;
using Kassan.Products;
using System.Collections.Generic;
using System.IO;

namespace Kassan.Products
{
    public class ProductStore : IFileReader, IFileWriter
    {

        private static ProductStore instance;
        private List<Product> products = new List<Product>();
        
        private readonly string filePath = "products.txt"; // File to store products.

        private ProductStore()
        {

        }
        // Add a product to the list
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Remove a product from the list
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        // Write the list of products to a file
        public void Write()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.ProductCode},{product.Price},{product.PriceType}");
                }

            }
        }

        // Read the list of products from a file
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

    }
}

//void AddProduct(Product productToAdd) {}
//void RemoveProduct(Product product) 
//void Persist() //save products to file -- finns som interface (Bra eller dåligt?)
//void Load() // read products from file -- finns som interface