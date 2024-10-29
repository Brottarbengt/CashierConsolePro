using Kassan.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.CampaignTools
{
    public static class CampaignManager
    {
        public static void AddCampaign()
        {
            
            Console.Clear();
            Console.WriteLine("Add Campaign");

            string campaignName = InputValidator.GetString("Enter Campaign Name: ");
            DateOnly campaignFromDate = InputValidator.GetDateOnly("Enter campaign from date (yyyy-mm-dd): ");
            DateOnly campaignToDate = InputValidator.GetDateOnly("Enter campaign to date (yyyy-mm-dd): ");
            decimal discount = InputValidator.GetDecimal("Enter discount percentage: ");
            
            Campaign campaign = new Campaign(campaignName, campaignFromDate, campaignToDate, discount);
            Campaigns.Instance().AddCampaign(campaign);
            Console.WriteLine("Enter product codes to be in campaign separate with , : ");
            string campaignProducts = Console.ReadLine();
            // logic for adding to Product.campaigns, refactor to new method()?

            Console.WriteLine("Campaign added successfully.");
            Console.ReadKey();
        }

        public static void RemoveCampaign()
        {
            Console.Clear();
            Console.WriteLine("Remove Campaign");

            ViewAllCampaigns();

            string campaignName = InputValidator.GetString("\nEnter the name of the campaign to remove: ");
            var campaignToRemove = Campaigns.Instance().GetAllCampaigns()
                .FirstOrDefault(c => c.CampaignName.Equals(campaignName, StringComparison.OrdinalIgnoreCase));

            if (campaignToRemove != null)
            {
                Campaigns.Instance().RemoveCampaign(campaignToRemove);
                Console.WriteLine($"Campaign '{campaignName}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Campaign '{campaignName}' not found.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        public static void ViewAllCampaigns()
        {
            Console.Clear();
            Console.WriteLine("All Campaigns");

            var campaigns = Campaigns.Instance().GetAllCampaigns();

            if (campaigns.Count == 0)
            {
                Console.WriteLine("No campaigns available.");
            }
            else
            {
                foreach (var campaign in campaigns)
                {
                    Console.WriteLine("\n=================================");
                    Console.WriteLine($"Name: {campaign.CampaignName}");
                    Console.WriteLine($"From Date: {campaign.CampaignFromDate:yyyy-MM-dd}");
                    Console.WriteLine($"To Date: {campaign.CampaignToDate:yyyy-MM-dd}");
                    Console.WriteLine($"Discount: {campaign.Discount}%");
                    Console.WriteLine("=================================\n");
                }
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}