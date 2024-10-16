using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassan.Products;

namespace Kassan.Shopping
{
    internal class ShoppingCart : IPay, IAddProductToCart
    {
        public List<Product> products = new List<Product>();


        public void CalculateSum()
        {

        }

        public void AddProductToCart(Product product)
        {
            products.Add(product);
        }
    }
}
