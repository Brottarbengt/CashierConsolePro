using CCP.CampaignTools;
using CCP.Graphic;
using CCP.Menus;
using CCP.Products;


namespace CCP
{
    public static class CashierConsolePro
    {
        public static void Start()
        {

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

                foreach (var campaign in campaigns.ToList()) // Use ToList() to safely modify collection - new knowledge aquired!
                {
                    if (campaign.CampaignToDate < today)
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
