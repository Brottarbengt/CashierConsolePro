using Kassan.CampaignTools.Kassan.CampaignTools;
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

        public DateOnly CampaignDate { get; set; }
        public double Discount { get; set; }


        // need more props? list of Product, how much % discount

        /* 
          Solution proposal 1
          
          prop Discount on Product.
                    
               for each (Campaign)
                   for each (prod in campaign)
                       prod.discount += campaign.discount
                       
          RemoveCampaign() Called on start, looping thru campaigns from file. 
               if (campaign date != valid)
                   Remove campaign from file,          
                   
          AddCampaign() updates price when called, also is called in start of program, reading campaign from list.
          
                     
            Solution 2
                referenser till Campaigns på Product. 
                Product.Price räknar du ut totala discount där.
                ändra/lägga till en prop på Product som håller ListPrice/BasePrice 
                och Price kan vara en beräknad prop som inkluderar rabatter
         */

    }

}
