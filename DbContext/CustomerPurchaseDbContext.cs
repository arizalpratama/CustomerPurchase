using Microsoft.EntityFrameworkCore;
using CustomerPurchase.Models;

namespace CustomerPurchase.DbContext
{
    public class CustomerPurchaseDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AVA3DPU\\SQLEXPRESS;Initial Catalog=CustomerPurchaseDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerCode);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(32);
                entity.Property(e => e.CustomerAddress).HasMaxLength(200);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("money");
                entity.Property(e => e.Item).HasMaxLength(200);
                entity.HasOne(p => p.Customer)
                      .WithMany(c => c.Purchases)
                      .HasForeignKey(p => p.CustomerCode);
            });
        }
    }
}