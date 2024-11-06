using CashierConsolePro.Graphic;
using CashierConsolePro.Menus;


namespace CashierConsolePro
{
    public static class CashierConsolePro
    {
        public static void Start()
        {
            // First load all products from file and store in ProductStore
            // then load campaigns from file and check if date is ok, if not, remove from campaign and products
            
            Console.Clear();
            Startscreen.Display();
            TopMenu.ShowMenu();
            
        }
    }
}
