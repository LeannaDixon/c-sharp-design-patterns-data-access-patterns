using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();


                //2. Find the service layer within our scope.
            //using (var scope = host.Services.CreateScope())
            //{
            //    //3. Get the instance of BoardGamesDBContext in our services layer
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<ShoppingContext>();

            //    //4. Call the DataGenerator to create sample data
            //    DataGenerator.Initialize(services);
            //}

            //Continue to run the application
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    internal class DataGenerator
    {
        internal static void Initialize(IServiceProvider services)
        {
            using (var context = new ShoppingContext(services.GetRequiredService<DbContextOptions<ShoppingContext>>()))
            {
                // Look for any board games.
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }

                context.Products.AddRange(
                     new Product { Name = "Canon EOS 70D", Price = 599m },
                    new Product { Name = "Shure SM7B", Price = 245m },
                    new Product { Name = "Key Light", Price = 59.99m },
                    new Product { Name = "Android Phone", Price = 259.59m },
                    new Product { Name = "5.1 Speaker System", Price = 799.99m }
                    );
            }
        
        }
    }
}
