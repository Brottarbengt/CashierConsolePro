using CashierConsolePro.CampaignTools;
using CashierConsolePro.Graphic;
using CashierConsolePro.Menus;
using CashierConsolePro.Products;


namespace CashierConsolePro
{
    public static class CashierConsolePro
    {
        public static void Start()
        {

            //Need Code to check for uniqe product codes = cant enter product if exists
            // Same with Campaign
            // First load all products from file and store in ProductStore
            // then load campaigns from file and check if date is ok, if not, remove from campaign and products
            StartupLoad();
            Console.Clear();
            Startscreen.Display();
            TopMenu.ShowMenu();
            
            
        }

        public static void StartupLoad()
        {
            {
                
                ProductStore.Instance().Read();
                Campaigns.Instance().Read();

                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                var campaigns = Campaigns.Instance().GetAllCampaigns();

                foreach (var campaign in campaigns.ToList()) // Use ToList() to safely modify collection
                {
                    if (campaign.CampaignToDate < today) // Check if campaign has expired
                    {
                        Campaigns.Instance().RemoveCampaign(campaign);

                        foreach (var product in ProductStore.Instance().GetAllProducts())
                        {
                            if (product.Campaigns.Contains(campaign))
                            {
                                product.Campaigns.Remove(campaign);
                            }
                        }
                    }
                }
            }
        }
    }
}
