using System;
using CustomerPurchase.DbContext;
using CustomerPurchase.Data;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new CustomerPurchaseDbContext())
        {
            try
            {
                // Inisialisasi data jika belum ada
                SampleData.Initialize(context);

                // Input untuk bulan
                Console.Write("Enter month (e.g., 12): ");
                string monthInput = Console.ReadLine();
                if (!int.TryParse(monthInput, out int month) || month < 1 || month > 12)
                {
                    Console.WriteLine("Invalid month. Please enter a number between 1 and 12.");
                    return;
                }

                // Input untuk tahun
                Console.Write("Enter year (e.g., 2024): ");
                string yearInput = Console.ReadLine();
                if (!int.TryParse(yearInput, out int year) || year < 1)
                {
                    Console.WriteLine("Invalid year. Please enter a positive number.");
                    return;
                }

                // Query LINQ untuk mendapatkan Top 3 Customers
                var topCustomers = context.Purchases
                    .Where(p => p.PurchaseDate.Month == month && p.PurchaseDate.Year == year)
                    .GroupBy(p => new
                    {
                        p.Customer.CustomerCode,
                        p.Customer.CustomerName,
                        p.Customer.CustomerAddress
                    })
                    .Select(g => new
                    {
                        g.Key.CustomerCode,
                        g.Key.CustomerName,
                        g.Key.CustomerAddress,
                        TotalPrice = g.Sum(p => p.Price)
                    })
                    .OrderByDescending(c => c.TotalPrice)
                    .Take(3)
                    .ToList();

                // Menampilkan hasil
                if (topCustomers.Any())
                {
                    Console.WriteLine("\nTop 3 Customers:");
                    foreach (var customer in topCustomers)
                    {
                        Console.WriteLine($"Customer Code: {customer.CustomerCode}");
                        Console.WriteLine($"Customer Name: {customer.CustomerName}");
                        Console.WriteLine($"Customer Address: {customer.CustomerAddress}");
                        Console.WriteLine($"Total Price: {customer.TotalPrice:C}");
                        Console.WriteLine("-----------------------");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo data found for the given month and year.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }
    }
}
