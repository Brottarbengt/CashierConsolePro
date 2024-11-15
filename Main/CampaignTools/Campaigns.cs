using CCP.FileManagement;


namespace CCP.CampaignTools
{
    public class Campaigns : IFileReader, IFileWriter
    {
        private static Campaigns instance;
        private List<Campaign> campaigns = new List<Campaign>();

        private readonly string filePath = "../../../campaigns.txt";

        public void AddCampaign(Campaign campaign)
        {
            campaigns.Add(campaign);
            Write();
        }

        public void RemoveCampaign(Campaign campaign)
        {
            campaigns.Remove(campaign);
        }

        public void Read()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    campaigns.Clear();
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split('*');
                        if (data.Length >= 4) 
                        {
                            string campaignName = data[0];

                            if (DateOnly.TryParse(data[1], out DateOnly campaignFromDate) &&
                                DateOnly.TryParse(data[2], out DateOnly campaignToDate) &&
                                decimal.TryParse(data[3], out decimal discount))
                            {
                                var campaign = new Campaign(campaignName, campaignFromDate, campaignToDate, discount);

                                if (data.Length == 5)
                                {
                                    string[] productCodes = data[4].Split('|', StringSplitOptions.RemoveEmptyEntries);
                                    campaign.DiscountedProductCodes = productCodes.ToList();
                                }

                                campaigns.Add(campaign);
                            }
                        }
                    }
                }
            }
        }

        public void Write()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var campaign in campaigns)
                {
                    
                    string discountedProducts = campaign.DiscountedProductCodes != null && campaign.DiscountedProductCodes.Any()
                        ? string.Join('|', campaign.DiscountedProductCodes)
                        : string.Empty;

                    
                    writer.WriteLine(
                        $"{campaign.CampaignName}*{campaign.CampaignFromDate:yyyy-MM-dd}*" +
                        $"{campaign.CampaignToDate:yyyy-MM-dd}*{campaign.Discount}*{discountedProducts}");
                }
            }
        }

        public List<Campaign> GetAllCampaigns()
        {
            return campaigns;
        }

        public static Campaigns Instance()
        {
            if (instance == null)
            {
                instance = new Campaigns();
            }
            return instance;
        }

        public bool IsCampaignNameUnique(string campaignName)
        {
            return !campaigns.Any(c => c.CampaignName.Equals(campaignName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
