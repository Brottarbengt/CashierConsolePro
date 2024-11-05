using Kassan.Products;
using Kassan.Utilities;


namespace Kassan.CampaignTools
{
    public static class CampaignManager
    {

        public static void AddCampaign()
        {
            
            Campaigns campaigns = Campaigns.Instance();

            Console.Clear();
            Console.WriteLine("Add Campaign");

            string campaignName = InputValidator.GetString("Enter Campaign Name: ");
            DateOnly campaignFromDate = InputValidator.GetDateOnly("Enter campaign from date (yyyy-mm-dd): ");
            DateOnly campaignToDate = InputValidator.GetDateOnly("Enter campaign to date (yyyy-mm-dd): ");
            decimal discount = InputValidator.GetDecimal("Enter discount percentage: ");

            Campaign campaign = new Campaign(campaignName, campaignFromDate, campaignToDate, discount);
            Campaigns.Instance().AddCampaign(campaign);
            Console.WriteLine("Enter product codes to be in campaign separated by commas: ");
            string campaignProducts = Console.ReadLine();

            if (!string.IsNullOrEmpty(campaignProducts))
            {
                string[] productCodes = campaignProducts.Split(',');

                foreach (string code in productCodes)
                {
                    string trimmedCode = code.Trim();

                    Product productToAdd = ProductStore.Instance().FindProduct(trimmedCode);

                    if (productToAdd != null)
                    {
                        campaigns.AddCampaign(campaign);

                        productToAdd.Campaigns.Add(campaign);
                    }
                    else
                    {
                        Console.WriteLine($"Product with code {trimmedCode} not found.");
                    }
                }

                Console.WriteLine("Campaign added successfully.");
                Console.ReadKey();
            }
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
                // Need to delete from products that had the campaign.
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