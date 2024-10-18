using Kassan.CampaignTools;
using Kassan.CampaignTools.Kassan.CampaignTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    AddCampaign.Execute();
                    break;
                case 1:
                    RemoveCampaign.Execute();
                    break;
                case 2:
                    ViewAllCampaigns();
                    break;
                case 3:
                    TopMenu.ShowMenu();  // Return to Top Menu
                    break;
                default:
                    break;
            }
        }

        private static void ViewAllCampaigns()
        {
            // Logic to display all campaigns
            Console.WriteLine("Viewing all campaigns...");
            Console.ReadLine();  // Pause for demo purposes
        }
    }
}