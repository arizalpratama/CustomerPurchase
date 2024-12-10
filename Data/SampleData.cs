using CustomerPurchase.DbContext;
using CustomerPurchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPurchase.Data
{
    public static class SampleData
    {
        public static void Initialize(CustomerPurchaseDbContext context)
        {
            // Periksa apakah data Customer sudah ada
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer { CustomerName = "John Doe", CustomerType = 1, CustomerAddress = "123 Main Street" },
                    new Customer { CustomerName = "Jane Smith", CustomerType = 2, CustomerAddress = "456 Elm Street" },
                    new Customer { CustomerName = "Robert Brown", CustomerType = 1, CustomerAddress = "789 Oak Street" },
                    new Customer { CustomerName = "Emily Davis", CustomerType = 2, CustomerAddress = "321 Willow Lane" },
                    new Customer { CustomerName = "Michael Johnson", CustomerType = 1, CustomerAddress = "654 Maple Avenue" },
                    new Customer { CustomerName = "Sophia Wilson", CustomerType = 1, CustomerAddress = "987 Cedar Road" },
                    new Customer { CustomerName = "James Taylor", CustomerType = 2, CustomerAddress = "567 Birch Street" },
                    new Customer { CustomerName = "Olivia Martinez", CustomerType = 1, CustomerAddress = "432 Pine Boulevard" },
                    new Customer { CustomerName = "William Lee", CustomerType = 1, CustomerAddress = "876 Spruce Drive" },
                    new Customer { CustomerName = "Emma Harris", CustomerType = 2, CustomerAddress = "234 Aspen Circle" }
                };

                context.Customers.AddRange(customers);
            }

            // Periksa apakah data Purchase sudah ada
            if (!context.Purchases.Any())
            {
                var purchases = new List<Purchase>
                {
                    new Purchase { CustomerCode = 1, Item = "Laptop", Price = 1500.00m, PurchaseDate = new DateTime(2024, 12, 1) },
                    new Purchase { CustomerCode = 2, Item = "Phone", Price = 800.00m, PurchaseDate = new DateTime(2024, 12, 2) },
                    new Purchase { CustomerCode = 3, Item = "Headphones", Price = 200.00m, PurchaseDate = new DateTime(2024, 12, 3) },
                    new Purchase { CustomerCode = 4, Item = "Monitor", Price = 300.00m, PurchaseDate = new DateTime(2024, 12, 4) },
                    new Purchase { CustomerCode = 5, Item = "Keyboard", Price = 100.00m, PurchaseDate = new DateTime(2024, 12, 5) },
                    new Purchase { CustomerCode = 6, Item = "Desk Chair", Price = 250.00m, PurchaseDate = new DateTime(2024, 12, 6) },
                    new Purchase { CustomerCode = 7, Item = "External Drive", Price = 120.00m, PurchaseDate = new DateTime(2024, 12, 7) },
                    new Purchase { CustomerCode = 8, Item = "Printer", Price = 200.00m, PurchaseDate = new DateTime(2024, 12, 8) },
                    new Purchase { CustomerCode = 9, Item = "Webcam", Price = 80.00m, PurchaseDate = new DateTime(2024, 12, 9) },
                    new Purchase { CustomerCode = 10, Item = "Smartwatch", Price = 400.00m, PurchaseDate = new DateTime(2024, 12, 10) }
                };

                context.Purchases.AddRange(purchases);
            }

            context.SaveChanges();
        }
    }
}