using Kassan.CampaignTools;
using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.CampaignTools
{
    public class Campaign
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
    }


}


// need more props? list of Product, how much % discount

/* 
 * 
 * Eller  referenser till Campaigns på Product. 
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