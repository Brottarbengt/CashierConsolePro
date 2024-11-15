using CCP.FileManagement;

namespace CCP.Shopping
{
    internal class Receipt : IFileWriter, IPay, ICalculateSum
    {
        public string Date { get; set; }
        public decimal Total { get; set; }        
        private ShoppingCart cart;
        private int receiptCount;

        public Receipt(ShoppingCart shoppingCart)
        {
            cart = shoppingCart;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Total = CalculateSum(cart);

            receiptCount = LoadReceiptCount();
            receiptCount++;  
        }

        private int LoadReceiptCount()
        {
            
            string receiptCountFile = "receiptCount.txt";
            if (File.Exists(receiptCountFile))
            {
                string lastCount = File.ReadAllText(receiptCountFile);
                if (int.TryParse(lastCount, out int lastReceiptCount))
                {
                    return lastReceiptCount;
                }
            }
            return 0;
        }

        private void SaveReceiptCount()
        {
            File.WriteAllText("../../../receiptCount.txt", receiptCount.ToString());
        }

      
        public void Write()
        {            
            string receiptFileName = $"../../../RECEIPT_{DateTime.Now:yyyyMMdd}.txt";

            using (StreamWriter writer = new(receiptFileName, true))
            {
                writer.WriteLine($"Receipt #{receiptCount}");
                writer.WriteLine($"Date: {Date}");
                writer.WriteLine("Items:");
                foreach (var item in cart.GetAllProducts())
                {
                    writer.WriteLine($"{item.Product.Name} - " +
                        $"{item.Product.ListPrice:C} " +
                        $"Discount {item.Product.Price - item.Product.ListPrice}");
                }
                writer.WriteLine($"Total: {Total:C}");
                writer.WriteLine($"=== END OF RECEIPT ===");
            }

            SaveReceiptCount();
        }

        public void CreateReceipt()
        {
            Write();
            Console.WriteLine("Receipt created and saved.");
        }

        public void DisplayReceipt()
        {
            Console.Clear();
            Console.WriteLine($"Receipt #{receiptCount}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine("Items:");
            foreach (var product in cart.GetAllProducts())
            {
                Console.WriteLine($"{product.Product.Name} - {product.Product.Price:C} " +
                    $"Discount {product.Product.ListPrice - product.Product.Price:C}" +
                    $"/ {product.Product.PriceType.ToString()}");
            }
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        
        public decimal CalculateSum(ShoppingCart cart)
        {
            decimal totalSum = 0;

            foreach (var item in cart.GetAllProducts())
            {
                totalSum += (decimal)item.Total;
            }

            return totalSum;
        }        
    }
}


