using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace _01_FirstStep
{
    public class TenantDatabaseProvider : ITenantDatabaseProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public TenantDatabaseProvider(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string GetTenantConnectionString()
        {
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("CompanyId"))
            {
                var companyId = _httpContextAccessor.HttpContext.Request.Headers["CompanyId"].FirstOrDefault();
                return _configuration.GetConnectionString($"CompanyId_{companyId}");
            }

            throw new InvalidOperationException("Missing tenant header!");
        }
    }
}