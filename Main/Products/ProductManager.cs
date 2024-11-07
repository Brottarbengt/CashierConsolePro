

using CashierConsolePro.Utilities;

namespace CashierConsolePro.Products
{
    public static class ProductManager
    {
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");

            string name = GetProductName();
            string code = GetProductCode();
            decimal listPrice = GetProductPrice();
            PriceType priceType = GetPriceType();

            if (IsValidProduct(name, code))
            {
                var newProduct = new Product(name, code, listPrice, priceType);
                ProductStore.Instance().AddProduct(newProduct);
                ProductStore.Instance().Write();
                Console.WriteLine("Product added successfully.");
            }

            Console.ReadKey();
        }

        private static string GetProductName()
        {
            string name;
            while (true)
            {
                name = InputValidator.GetString("Enter Product Name: ");
                if (InputValidator.IsValidName(name))
                {
                    break;
                }
                Console.WriteLine("Product name cannot be empty.");
            }
            return name;
        }

        private static string GetProductCode()
        {
            string code;
            while (true)
            {
                code = InputValidator.GetString("Enter Product Code: ");
                if (InputValidator.IsValidCodeLength(code))
                {
                    break;
                }
                Console.WriteLine("Product code must be at least 3 characters long.");
            }
            return code;
        }

        private static decimal GetProductPrice()
        {
            return InputValidator.GetDecimal("Enter Product Price: ");
        }

        private static PriceType GetPriceType()
        {
            PriceType priceType;
            while (true)
            {
                string priceTypeInput = InputValidator.GetString("Enter Price type (Weight = 0, Each = 1): ");
                if (Enum.TryParse(priceTypeInput, out priceType))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter 0 for Weight or 1 for Each.");
            }
            return priceType;
        }

        private static bool IsValidProduct(string name, string code)
        {
            if (!ProductStore.Instance().IsProductUnique(name, code))
            {
                Console.WriteLine("A product with the same name or code already exists.");
                return false;
            }
            return true;
        }

        public static void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product from store");
            ShowAllProducts();

            Console.Write("Enter Product Code to Remove: ");
            string code = Console.ReadLine();
            var productStore = ProductStore.Instance();

            Product productToRemove = productStore.FindProduct(code);

            if (productToRemove != null)
            {
                productStore.RemoveProduct(productToRemove);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.ReadKey();

        }

        public static void ShowAllProducts()
        {
            Console.Clear();
            var productStore = ProductStore.Instance();
            Console.WriteLine("\n  Products in store: ");
            foreach (var product in productStore.GetAllProducts())
            {
                Console.WriteLine(
                  $"{product.Name}, " +
                  $"Code: {product.ProductCode}, " +
                  $"Price: {product.ListPrice} / Discounted: {product.Price}, " +
                  $"{product.PriceType}");
            }
            Console.ReadKey();

        }

        public static void ChangeProductName()
        {
            Console.Clear();
            Console.WriteLine("Change Product Name");

            ShowAllProducts();

            Console.Write("Enter Product Code to Change Name: ");
            string code = Console.ReadLine();
            var productStore = ProductStore.Instance();

            Product productToUpdate = productStore.FindProduct(code);

            if (productToUpdate != null)
            {
                string newName = GetProductName();
                productToUpdate.SetName(newName);
                productStore.Write();
                Console.WriteLine($"Product name updated to {newName}.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.ReadKey();
        }
        public static void ChangeProductPrice()
        {
            Console.Clear();
            Console.WriteLine("Change Product Price");

            ShowAllProducts();

            Console.Write("Enter Product Code to Change Price: ");
            string code = Console.ReadLine();
            var productStore = ProductStore.Instance();

            Product productToUpdate = productStore.FindProduct(code);

            if (productToUpdate != null)
            {
                decimal newPrice = GetProductPrice();
                productToUpdate.ListPrice = newPrice;
                productStore.Write(); 
                Console.WriteLine($"Product price updated to {newPrice:C}.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.ReadKey();
        }
    }
}
