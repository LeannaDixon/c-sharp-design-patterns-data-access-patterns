using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;

namespace MyShop.Infrastructure
{

    public class ShoppingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // optionsBuilder
        //    //    // .UseLazyLoadingProxies()
        //    // .UseSqlite("Data Source=orders.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Ignore(customer => customer.ProfilePicture);

            //modelBuilder.Entity<Product>()
            //    .HasData(new Product[]
            //    {
            //        new Product { Name = "Canon EOS 70D", Price = 599m },
            //        new Product { Name = "Shure SM7B", Price = 245m },
            //        new Product { Name = "Key Light", Price = 59.99m },
            //        new Product { Name = "Android Phone", Price = 259.59m },
            //        new Product { Name = "5.1 Speaker System", Price = 799.99m }
            //    });

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Name = "Canon EOS 70D", Price = 599m },
                    new Product { Name = "Shure SM7B", Price = 245m },
                    new Product { Name = "Key Light", Price = 59.99m },
                    new Product { Name = "Android Phone", Price = 259.59m },
                    new Product { Name = "5.1 Speaker System", Price = 799.99m }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
