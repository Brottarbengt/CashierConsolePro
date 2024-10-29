using Kassan.CampaignTools;
using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kassan.Menus
{
    public static class CampaignMenu
    {
        private static string[] menuOptions = new string[] { "Add Campaign", "Remove Campaign", "View All Campaigns", "Back to Top Menu" };

        public static void ShowMenu()
        {
            MenuGenerator.ShowMenu("Campaign Menu", menuOptions, ExecuteSelectedOption);
        }

        private static void ExecuteSelectedOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    CampaignManager.AddCampaign();
                    break;
                case 1:
                    CampaignManager.RemoveCampaign();
                    break;
                case 2:
                    CampaignManager.ViewAllCampaigns();
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