using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Menus
{
    public static class ProductsMenu 
    {

        private static string[] menuOptions = new string[] { "Add Product", "Remove Product", "Show All Products", "Back to Top Menu" };

        public static void ShowMenu()
        {
            MenuGenerator.ShowMenu("Products Menu", menuOptions, ExecuteSelectedOption);
        }

        private static void ExecuteSelectedOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    AddProduct(); 
                    break;
                case 1:
                    RemoveProduct();
                    break;
                case 2:
                    ShowAllProducts();
                    break;
                case 3:
                    TopMenu.ShowMenu();  
                    break;
                default:
                    break;
            }
        }
        private static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");

            // Get Product details from the user
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            decimal listPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Price type (Weight = 0, Each = 1): ");
            PriceType priceType = Enum.Parse<PriceType>(Console.ReadLine());

            // Create a new Product and add it to the store
            Product newProduct = new Product(name, code, listPrice, priceType);
            ProductStore.Instance().AddProduct(newProduct);

            Console.WriteLine("Product added successfully.");
            Console.ReadKey();
            ShowMenu();
        }

        private static void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product");

            // Get Product code from the user
            Console.Write("Enter Product Code to Remove: ");
            string code = Console.ReadLine();
            var productStore = ProductStore.Instance();

            // Find the Product in the store
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
            ShowMenu();
        }

        private static void ShowAllProducts()
        {
            Console.Clear();
            var productStore = ProductStore.Instance();
            Console.WriteLine("\n  Products in store: ");
            foreach (var product in productStore.GetAllProducts())
            {
                Console.WriteLine(
                    $"{product.Name}, {product.ProductCode}, {product.ListPrice} / {product.Price}, {product.PriceType}");
            }
            Console.ReadKey();
            ShowMenu();
        }
    }
}
