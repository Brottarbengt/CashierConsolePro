

namespace CCP.Menus
{
    public static class TopMenu
    {
        private static string[] menuOptions = new string[] { "New Customer", "Products Menu", "Campaign Menu", "Exit" };

        public static void ShowMenu()
        {
            MenuGenerator.ShowMenu("Top Menu", menuOptions, ExecuteSelectedOption);
        }

        private static void ExecuteSelectedOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ShoppingMenu.CashierConsole();
                    break;
                case 1:
                    ProductsMenu.ShowMenu();
                    break;
                case 2:                    
                    CampaignMenu.ShowMenu();
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
