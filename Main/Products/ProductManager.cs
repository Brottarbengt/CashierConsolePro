

namespace CashierConsolePro.Products
{
    public static class ProductManager
    {
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            decimal listPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Price type (Weight = 0, Each = 1): ");
            PriceType priceType = Enum.Parse<PriceType>(Console.ReadLine());

            
            Product newProduct = new Product(name, code, listPrice, priceType);
            ProductStore.Instance().AddProduct(newProduct);

            Console.WriteLine("Product added successfully.");
            Console.ReadKey();            
        }

        public static void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product from store");

            Console.Write("Enter Product Code to Remove: ");
            string code = Console.ReadLine();
            var productStore = ProductStore.Instance();

            Product productToRemove = productStore.FindProduct(code);

            if (productToRemove != null)
            {
                productStore.RemoveProduct(productToRemove);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.ReadKey();
            
        }
        public static void ShowAllProducts()
        {
            Console.Clear();
            var productStore = ProductStore.Instance();
            Console.WriteLine("\n  Products in store: ");
            foreach (var product in productStore.GetAllProducts())
            {
                Console.WriteLine(
                    $"{product.Name}, {product.ProductCode}, {product.ListPrice} / {product.Price}, {product.PriceType}");
            }
            Console.ReadKey();
            
        }
    }
}
