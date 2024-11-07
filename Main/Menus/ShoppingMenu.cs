using CashierConsolePro.Products;
using CashierConsolePro.Shopping;
using CashierConsolePro.Utilities;



namespace CashierConsolePro.Menus
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

            Console.WriteLine("Commands: \n <product code> <amount> Or just type 'PAY' for checkout");

            var commands = Console.ReadLine().Split(" ");

            if (commands.Length == 1 && InputValidator.IsPayCommand(commands[0]))
            {
                var receipt = cart.CheckOut();
                receipt.CreateReceipt();
                receipt.DisplayReceipt();
            }
            else if (commands.Length == 2 && InputValidator.IsValidProductCode(commands[0]) && InputValidator.IsValidAmount(commands[1]))
            {
                var productStore = ProductStore.Instance();
                var product = productStore.FindProduct(commands[0]);
                var amount = int.Parse(commands[1]);
                var cartItem = new CartItem(amount, product);
                cart.AddProductToCart(cartItem);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid product code and amount, or type 'PAY' to checkout.");
            }
        }
    }
}
