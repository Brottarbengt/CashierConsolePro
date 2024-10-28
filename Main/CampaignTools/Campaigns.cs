using Kassan.FileManagement;
using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kassan.CampaignTools
{
    public class Campaigns : IFileReader, IFileWriter
    {
        private static Campaigns instance;
        private List<Campaign> campaigns = new List<Campaign>();

        private readonly string filePath = "campaigns.txt";

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
                        var data = line.Split(',');                     // OBS OBS! Funkar inte med DateOnly
                        if (data.Length == 4)
                        {
                            string campaignName = data[0];
                            string campaignFromDate = data[1];
                            string CampaignToDate = data[2];
                            if (decimal.TryParse(data[3], out decimal discount))
                            {
                                campaigns.Add(new Campaign(campaignName, campaignFromDate, CampaignToDate, discount));
                            }

                        }
                    }
                }
            }
        }
        //CampaignName = name;
        //    CampaignFromDate = from;
        //    CampaignToDate = to;
        //    Discount = discount;
        public void Write()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var campaign in campaigns)
                {
                    writer.WriteLine(
                        $"{campaign.CampaignName},{campaign.CampaignFromDate}," +
                        $"{campaign.CampaignToDate},{campaign.Discount}");
                   
                }

            }
        }

        public static Campaigns Instance()
        {
            if (instance == null)
            {
                instance = new Campaigns();
            }
            return instance;
        }
    }
}
