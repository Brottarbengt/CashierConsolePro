using Kassan.FileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Products
{
    internal class ProductStore : IFileReader, IFileWriter, IRemoveProduct, IAddProduct
    {
        private List<Product> products = new List<Product>();

        

        public void Write()
        {
            // Write to file
        }

        public void Read()
        {
            // Read from file
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }

}
//void AddProduct(Product productToAdd) {}
//void RemoveProduct(Product product) 
//void Persist() //save products to file -- finns som interface (Bra eller dåligt?)
//void Load() // read products from file -- finns som interface