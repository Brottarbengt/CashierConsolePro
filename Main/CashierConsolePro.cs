using Kassan.Graphic;
using Kassan.Menus;


namespace Kassan
{
    public static class CashierConsolePro
    {
        public static void Start()
        {
            // need to load campaigns and check if date is ok, if not, remove
            Console.Clear();
            Startscreen.Display();
            TopMenu.ShowMenu();
            
        }
    }
}
