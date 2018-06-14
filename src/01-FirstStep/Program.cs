using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace _01_FirstStep
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .SeedDatabase((context, services) =>
                {
                    context.Database.Migrate();
                    context.Superheros.Add(new Superhero()
                    {
                        Age = 40,
                        IsDcSuperhero = false,
                        Name = "Sergius",
                        NationalId = "AAB44434"
                    });
                    context.SaveChanges();
                })
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}