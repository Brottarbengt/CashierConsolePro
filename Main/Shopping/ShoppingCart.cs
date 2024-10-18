using Kassan.CampaignTools;
using Kassan.FileManagement;
using Kassan.Products;
using System.Collections.Generic;

namespace Kassan.Shopping
{
    internal class ShoppingCart : IAddProductToCart, IRemoveFromCart
    {
        public List<Product> products = new List<Product>();

        /// <summary>
        /// Add product to the cart
        /// </summary>
        /// <param name="product"></param>
        public void AddProductToCart(Product product)
        {
            products.Add(product);
        }

        /// <summary>
        /// Remove product from the cart
        /// </summary>
        /// <param name="product"></param>
        public void RemoveFromCart(Product product)
        {
            products.Remove(product);
        }

        /// <summary>
        /// Get all products in the cart
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return new List<Product>(products);
        }
    }
}
