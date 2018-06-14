using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using _01_FirstStep;

namespace _01_FirstStep
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<SuperheroContext>
    {
        public SuperheroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SuperheroContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfCoreMultitenant-1-FirstStep;Trusted_Connection=True;");

            return new SuperheroContext(optionsBuilder.Options);
        }
    }
}