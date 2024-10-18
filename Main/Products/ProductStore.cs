using Kassan.CampaignTools;
using Kassan.CampaignTools.Kassan.CampaignTools;
using Kassan.FileManagement;
using Kassan.Products;
using System.Collections.Generic;
using System.IO;

namespace Kassan.Products
{
    internal class ProductStore : IFileReader, IFileWriter
    {
        private List<Product> products = new List<Product>();
        private readonly string filePath = "products.txt"; // File to store products.

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
                    writer.WriteLine($"{product.Name},{product.ProductCode},{product.Price}");
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
                        if (data.Length == 3)
                        {
                            string name = data[0];
                            string productCode = data[1];
                            if (decimal.TryParse(data[2], out decimal price))
                            {
                                products.Add(new Product(name, productCode, price));
                            }

                        }
                    }
                }
            }
        }

        
        public List<Product> GetAllProducts()
        {
            return new List<Product>(products);
        }

    }
}

//void AddProduct(Product productToAdd) {}
//void RemoveProduct(Product product) 
//void Persist() //save products to file -- finns som interface (Bra eller dåligt?)
//void Load() // read products from file -- finns som interface