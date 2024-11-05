

namespace Kassan.Graphic
{
    public static class Startscreen
    {
        public static void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"

             $$$$$$\   $$$$$$\  $$$$$$$\  
            $$  __$$\ $$  __$$\ $$  __$$\ 
            $$ /  \__|$$ /  \__|$$ |  $$ |
            $$ |      $$ |      $$$$$$$  |
            $$ |      $$ |      $$  ____/ 
            $$ |  $$\ $$ |  $$\ $$ |      
            \$$$$$$  |\$$$$$$  |$$ |      
             \______/  \______/ \__|      
                             
           ");

            Console.SetCursorPosition(3, 12);
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Cashier Console Pro!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("               ( O O P inside! ) ");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
