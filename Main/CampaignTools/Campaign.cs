using Kassan.CampaignTools.Kassan.CampaignTools;
using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.CampaignTools
{
    public class Campaign : IAddCampaign, IRemoveCampaign
    {
        public string CampaignName { get; set; }
        public DateOnly CampaignFromDate { get; set; }
        public DateOnly CampaignToDate { get; set; }
        public decimal Discount { get; set; }

        public Campaign(string name, DateOnly from, DateOnly to, decimal discount)
        {
            CampaignName = name;
            CampaignFromDate = from;
            CampaignToDate = to;
            Discount = discount;
        }
        
        public void AddCampaigns()
        {
            
            Console.Clear();
            Console.WriteLine("Add Campaign");

            // Get product details from the user
            Console.Write("Enter Campaign Name: ");
            string campaignName = Console.ReadLine();
            Console.Write("Enter campaign from date (yyyy, mm, dd): ");
            string campaignFromDate = Console.ReadLine();
            Console.Write("Enter campaign to date (yyyy, mm, dd): ");
            string campaignToDate = Console.ReadLine();

                // Create a new Product and add it to the store
            Campaign campaign = new Campaign(name, from, to, discount);
            ProductStore.Instance().AddProduct(newProduct);

            Console.WriteLine("Product added successfully.");
            Console.ReadKey();
            ShowMenu();
            
        }

        public void RemoveCampaigns(Campaign campaign)
        {

        }
    }


}


// need more props? list of Product, how much % discount

/* 
 * 
 * Eller så har du referenser till Campains på Product. 
 * Så när du gör Product.Price så räknar du ut totala discount där.
Du skulle kunna ändra/lägga till en prop på Product som 
håller ListPrice/BasePrice och Price kan vara en beräknad prop som inkluderar rabatter
 * 
 * 
 * 
  Solution proposal 1  

  prop Discount on Product.

       for each (Campaign)
           for each (prod in campaign)
               prod.discount += campaign.discount

  IRemoveCampaign() Called on start, looping thru campaigns from file. 
       if (campaign date != valid)
           Remove campaign from file,          

  IAddCampaign() updates price when called, also is called in start of program, reading campaign from list.


    Solution 2
        referenser till Campaigns på Product. 
        Product.Price räknar du ut totala discount där.
        ändra/lägga till en prop på Product som håller ListPrice/BasePrice 
        och Price kan vara en beräknad prop som inkluderar rabatter


Solution 3
 Observer pattern?
 */