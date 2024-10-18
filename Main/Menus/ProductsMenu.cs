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
                    ProductStore(); // Should be add product somehow
                    break;
                case 1:
                    RemoveProduct.Execute();
                    break;
                case 2:
                    ShowAllProducts();
                    break;
                case 3:
                    TopMenu.ShowMenu();  // Return to Top Menu
                    break;
                default:
                    break;
            }
        }

        private static void ShowAllProducts()
        {
            // Logic to display all products
            Console.WriteLine("Showing all products...");
            Console.ReadLine();  // Pause for demo purposes
        }
    }
}
