

namespace CCP.CampaignTools
{
    public class Campaign
    {
        public string CampaignName { get; set; }
        public DateOnly CampaignFromDate { get; set; }
        public DateOnly CampaignToDate { get; set; }
        public decimal Discount { get; set; }
        public List<string> DiscountedProductCodes { get; set; } = new List<string>();

        public Campaign(string name, DateOnly from, DateOnly to, decimal discount)
        {
            CampaignName = name;
            CampaignFromDate = from;
            CampaignToDate = to;
            Discount = discount;
            
        }                
    }
}
