using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _01_FirstStep
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddTransient<SuperheroContext>((ctx) =>
            {
                var tenantDatabaseProvider = ctx.GetService<ITenantDatabaseProvider>();
                return new SuperheroContext(tenantDatabaseProvider);
            });

            services.AddTransient<ITenantDatabaseProvider, TenantDatabaseProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}