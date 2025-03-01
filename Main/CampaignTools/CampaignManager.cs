﻿using CCP.Products;
using CCP.Utilities;


namespace CCP.CampaignTools
{
    public static class CampaignManager
    {

        public static void AddCampaign()
        {
            
            Campaigns campaigns = Campaigns.Instance();

            Console.Clear();
            ViewAllCampaigns();
            Console.WriteLine("Add Campaign");

            string campaignName = GetCampaignName();

            if (!campaigns.IsCampaignNameUnique(campaignName))
            {
                Console.WriteLine("A campaign with the same name already exists. Please try again.");
                return;
            }

            DateOnly campaignFromDate = InputValidator.GetDateOnly("Enter campaign from date (yyyy-mm-dd): ");
            DateOnly campaignToDate = InputValidator.GetDateOnly("Enter campaign to date (yyyy-mm-dd): ");
            decimal discount = InputValidator.GetDecimal("Enter discount percentage: ");

            Campaign campaign = new Campaign(campaignName, campaignFromDate, campaignToDate, discount);

            ProductManager.ShowAllProducts();

            Console.WriteLine("Enter product codes to be in campaign separated by commas if more than one: ");
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
                        productToAdd.Campaigns.Add(campaign);
                        campaign.DiscountedProductCodes.Add(trimmedCode);
                    }
                    else
                    {
                        Console.WriteLine($"Product with code {trimmedCode} not found.");
                    }
                }

                campaigns.AddCampaign(campaign);
                Console.WriteLine("Campaign added successfully.");
                Console.ReadKey();
            }
        }
        private static string GetCampaignName()
        {
            
            string name;
            while (true)
            {
                name = InputValidator.GetString("(Campaign name cannot be empty and cannot contain '*')\nEnter Campaign Name: ");
                if (InputValidator.IsValidName(name))
                {
                    break;
                }
                Console.WriteLine("Campaign name cannot be empty and cannot contain '*'. Please try again.");
            }
            return name;
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

                foreach (var product in ProductStore.Instance().GetAllProducts())
                {
                    if (product.Campaigns.Contains(campaignToRemove))
                    {
                        product.Campaigns.Remove(campaignToRemove);
                    }
                }

                Console.WriteLine($"Campaign '{campaignName}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Campaign '{campaignName}' not found.");
            }

            Console.WriteLine("\nPress any key to proceed...");
            Console.ReadKey();
        }

        public static void ViewAllCampaigns()
        {
            Console.Clear();
            Console.WriteLine("All Campaigns");

            var campaigns = Campaigns.Instance().GetAllCampaigns();
            var products = ProductStore.Instance().GetAllProducts();

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
                    
                    bool hasAssociatedProducts = false;
                    Console.Write("Products: ");

                    foreach (var product in products)
                    {
                        if (product.Campaigns.Contains(campaign))
                        {
                            Console.Write($"{product.Name}, ");
                            hasAssociatedProducts = true;
                        }
                    }

                    if (!hasAssociatedProducts)
                    {
                        Console.WriteLine("No products associated with this campaign.");
                    }
                    Console.WriteLine("\n=================================\n");
                }
            }

            Console.WriteLine("\nPress any key to proceed...");
            
        }
    }
}