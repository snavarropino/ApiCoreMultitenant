using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace _01_FirstStep
{
    public class SuperheroContext : DbContext
    {
        private readonly ITenantDatabaseProvider _tenantProvider;

        public SuperheroContext(DbContextOptions options) : base(options)
        {
        }

        public SuperheroContext(ITenantDatabaseProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Superhero> Superheros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_tenantProvider.GetTenantConnectionString());
            }
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}