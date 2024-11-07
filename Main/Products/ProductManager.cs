

using CashierConsolePro.Utilities;

namespace CashierConsolePro.Products
{
    public static class ProductManager
    {
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");

            string name = InputValidator.GetString("Enter Product Name: ");
            string code = InputValidator.GetString("Enter Product Code: ");
            decimal listPrice = InputValidator.GetDecimal("Enter Product Price: ");
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

            if (ProductStore.Instance().IsProductUnique(name, code))  // Call unique check method
            {
                Product newProduct = new Product(name, code, listPrice, priceType);
                ProductStore.Instance().AddProduct(newProduct);
                ProductStore.Instance().Write();
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("A product with the same name or code already exists.");
            }

            Console.ReadKey();
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
                  $"{product.Name}, {product.ProductCode}, {product.ListPrice} / Discounted: {product.Price}, {product.PriceType}");
            }
            Console.ReadKey();
            
        }

    }
}
