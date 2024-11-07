using CCP.Products;
using CCP.Shopping;
using CCP.Utilities;



namespace CCP.Menus
{
    public static class ShoppingMenu
    {
        public static void CashierConsole()
        {
            
            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("|Cashier console|");

                foreach (var item in cart.GetAllProducts())
                {
                    Console.WriteLine($"{item.Product.Name} , " +
                        $"Amount: {item.Amount} * " +
                        $"Price: {item.Product.Price} " +
                        $"= {item.Total}");                                     

                }

                Console.WriteLine("\nCommands: \n <product code> <amount> Or type 'PAY' for checkout");

                var commands = Console.ReadLine().Split(" ");

                if (commands.Length == 1 && InputValidator.IsPayCommand(commands[0]))
                {
                    var receipt = cart.CheckOut();
                    receipt.CreateReceipt();
                    receipt.DisplayReceipt();
                    break;  
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
}
