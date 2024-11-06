
namespace CashierConsolePro.Utilities
{
    public static class InputValidator
    {
        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static DateOnly GetDateOnly(string prompt)
        {
            DateOnly date;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateOnly.TryParse(input, out date))
                {
                    break;
                }
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format.");
            }
            return date;
        }

        public static decimal GetDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out value))
                {
                    break;
                }
                Console.WriteLine("Invalid number format. Please enter a numeric value.");
            }
            return value;
        }
    }
}
