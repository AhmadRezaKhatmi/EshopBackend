using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Utilities.Extensions.Connection
{
    public static class ConnectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
           IConfiguration configuration)
        {
            service.AddDbContext<EshopBackendDBContext>(options =>
            {
                var connectionString = "ConnectionStrings:EshopBackendConnection:Development";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }
    }
}
