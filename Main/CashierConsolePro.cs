using Kassan.Graphic;
using Kassan.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan
{
    public static class CashierConsolePro
    {
        public static void Start()
        {

            Console.Clear();
            Startscreen.Display();
            Console.ReadKey();
            Console.Clear();
            TopMenu.ShowMenu();
            
        }
    }
}
