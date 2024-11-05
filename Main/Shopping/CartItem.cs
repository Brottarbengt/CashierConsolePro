using Kassan.Products;


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
