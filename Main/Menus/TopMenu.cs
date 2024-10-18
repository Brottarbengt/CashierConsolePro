using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Menus
{
    public static class TopMenu
    {
        private static string[] menuOptions = new string[] { "Campaign Menu", "Products Menu", "New Customer" };

        public static void ShowMenu()
        {
            MenuGenerator.ShowMenu("Top Menu", menuOptions, ExecuteSelectedOption);
        }

        private static void ExecuteSelectedOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    CampaignMenu.ShowMenu();
                    break;
                case 1:
                    ProductsMenu.ShowMenu();
                    break;
                case 2:
                    // NewCustomer logic will be added later
                    break;
                default:
                    break;
            }
        }
    }
}
