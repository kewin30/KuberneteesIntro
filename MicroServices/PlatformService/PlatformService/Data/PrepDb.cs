using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
        private static void SeedData(AppDbContext context, bool isProd) 
        {
            if (isProd)
            {
                Console.WriteLine("->> Applying migration");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Could not run migration {ex.Message}");
                }
                
            }

            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name="Dot net", 
                        Publisher="Microsoft",
                        Cost="free"
                    },
                    new Platform()
                    {
                        Name = "Sql Server",
                        Publisher = "Microsoft",
                        Cost = "free"
                    }, 
                    new Platform()
                    {
                        Name = "Docker",
                        Publisher = "Docker",
                        Cost = "free"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
