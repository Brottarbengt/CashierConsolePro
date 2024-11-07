using CCP.Products;


namespace CCP.Menus
{
    public static class ProductsMenu 
    {

        private static string[] menuOptions = new string[] {
            "Add Product",
            "Remove Product",
            "Show All Products",
            "Change Product Name",
            "Change Product Price",
            "Back to Top Menu"
        };

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
                    ProductManager.ChangeProductName(); 
                    break;
                case 4:
                    ProductManager.ChangeProductPrice(); 
                    break;
                case 5:
                    TopMenu.ShowMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
