using Kassan.Products;


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
                    ProductManager.AddProduct(); 
                    break;
                case 1:
                    ProductManager.RemoveProduct();
                    break;
                case 2:
                    ProductManager.ShowAllProducts();
                    break;
                case 3:
                    TopMenu.ShowMenu();  
                    break;
                default:
                    break;
            }
        }                
    }
}
