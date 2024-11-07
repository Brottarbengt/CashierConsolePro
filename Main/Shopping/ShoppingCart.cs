

namespace CCP.Shopping
{
    internal class ShoppingCart : IAddProductToCart, IRemoveFromCart
    {
        private List<CartItem> products = new List<CartItem>();

        public void AddProductToCart(CartItem product)
        {
            products.Add(product);
        }

        public void RemoveFromCart(CartItem product)
        {
            products.Remove(product);
        }

        public List<CartItem> GetAllProducts()
        {
            return products;
        }

        public Receipt CheckOut()
        {
            return new Receipt(this);
        }
    }
}
