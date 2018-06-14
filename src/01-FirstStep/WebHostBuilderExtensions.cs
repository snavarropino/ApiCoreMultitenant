using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _01_FirstStep
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHost SeedDatabase(this IWebHost webHost, Action<SuperheroContext, IServiceProvider> seeder) 
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetService<IConfiguration>();

                foreach (var connectionStringElement in configuration.GetSection("ConnectionStrings").GetChildren())
                {
                    var connectionString = connectionStringElement.Value;
                    var optionsBuilder = new DbContextOptionsBuilder<SuperheroContext>();
                    optionsBuilder.UseSqlServer(connectionString);

                    using (var ctx =new SuperheroContext(optionsBuilder.Options ))
                    {
                        seeder(ctx, scope.ServiceProvider);
                    }
                }
            }
            return webHost;
        }
    }
}
