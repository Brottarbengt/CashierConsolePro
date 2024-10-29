using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Shopping
{
    internal class CartItem
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
        public decimal Total => Amount * Product.Price;

        public CartItem(int amount, Product product) 
        {
            Amount = amount;
            Product = product;
        }
    }
}
