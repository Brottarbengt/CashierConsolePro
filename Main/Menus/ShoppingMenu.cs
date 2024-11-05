using Kassan.Products;
using Kassan.Shopping;



namespace Kassan.Menus
{
    public static class ShoppingMenu
    {
        public static void CashierConsole()
        {
            ShoppingCart cart = new ShoppingCart();
            Console.WriteLine("|Cashier console|");
            foreach (var item in cart.GetAllProducts())
            {
                Console.WriteLine($"{item.Product.Name} , {item.Amount} * {item.Product.Price} = {item.Total}");

            }
            Console.WriteLine("Commands: \n <product code> <amount> Or just PAY for check out");
            var commands = Console.ReadLine().Split(" ");
            if ("PAY".Equals(commands[0]))
            {
                var receipt = cart.CheckOut();
                receipt.CreateReceipt();
                receipt.DisplayReceipt();
            }
            else
            {
                var productStore = ProductStore.Instance();
                var product = productStore.FindProduct(commands[0]);
                var amount = int.Parse(commands[1]);
                var cartItem = new CartItem(amount, product);
                cart.AddProductToCart(cartItem);
            }

        }
    }
}
