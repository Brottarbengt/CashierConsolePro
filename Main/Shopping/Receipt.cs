using Kassan.FileManagement;
using Kassan.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kassan.Shopping
{
    internal class Receipt : IFileWriter, IFileReader, IPay, ICalculateSum
    {
        public string Date { get; set; }
        public double Total { get; set; }
        public static int receiptCount = 0;
        private string receiptPath = "/receipts.txt"; 
        private ShoppingCart cart;

        public Receipt(ShoppingCart shoppingCart)
        {
            cart = shoppingCart;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Total = CalculateSum(cart);
            receiptCount++;
            
        }

        // Write receipt to file
        public void Write()
        {
            using (StreamWriter writer = new(receiptPath, true))
            {
                writer.WriteLine($"Receipt #{receiptCount}");
                writer.WriteLine($"Date: {Date}");
                writer.WriteLine("Items:");
                foreach (var product in cart.GetAllProducts())
                {
                    writer.WriteLine($"{product.Product.Name} - {product.Product.ListPrice:C} Discount {product.Product.Price - product.Product.ListPrice}");
                }
                writer.WriteLine($"Total: {Total:C}");
                writer.WriteLine("----------------------------------");
            }
        }

        // Read receipts from file
        public void Read()
        {
            if (File.Exists(receiptPath))
            {
                string receipts = File.ReadAllText(receiptPath);
                Console.WriteLine(receipts);
            }
            else
            {
                Console.WriteLine("No receipts available.");
            }
        }

        // Create receipt and save it to a file
        public void CreateReceipt()
        {
            Write();
            Console.WriteLine("Receipt created and saved.");
        }

        // Display the receipt and wait for user
        public void DisplayReceipt()
        {
            Console.Clear();
            Console.WriteLine($"Receipt #{receiptCount}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine("Items:");
            foreach (var product in cart.GetAllProducts())
            {
                Console.WriteLine($"{product.Product.Name} - {product.Product.Price:C} / {product.Product.PriceType.ToString()}");
            }
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        
        // Show all receipts from receipt file
        public void ShowAllReceipts()
        {
            Read();
        }

        // Calculate the total sum in the cart
        public double CalculateSum(ShoppingCart cart)
        {
            double totalSum = 0;

            foreach (var item in cart.GetAllProducts())
            {
                totalSum += (double)item.Total; 
            }

            return totalSum;
        }
    }
}


