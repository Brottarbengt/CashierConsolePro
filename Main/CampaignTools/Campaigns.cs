using CCP.FileManagement;


namespace CCP.CampaignTools
{
    public class Campaigns : IFileReader, IFileWriter
    {
        private static Campaigns instance;
        private List<Campaign> campaigns = new List<Campaign>();

        private readonly string filePath = "./campaigns.txt";

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
                        var data = line.Split(',');
                        if (data.Length == 4)
                        {
                            string campaignName = data[0];
                            if (DateOnly.TryParse(data[1], out DateOnly campaignFromDate) &&
                                DateOnly.TryParse(data[2], out DateOnly campaignToDate) &&
                                decimal.TryParse(data[3], out decimal discount))
                            {
                                campaigns.Add(new Campaign(campaignName, campaignFromDate, 
                                    campaignToDate, discount));
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
                    writer.WriteLine(
                        $"{campaign.CampaignName},{campaign.CampaignFromDate.ToString("yyyy-MM-dd")}," +
                        $"{campaign.CampaignToDate.ToString("yyyy-MM-dd")},{campaign.Discount}");
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
