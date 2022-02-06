using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;

namespace Data
{
    public static class PickPointDbContextExtensions
    {
        public static void AddPickPointDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PickPointDbContext>(options => options.UseNpgsql(connectionString));
        }

        public static void RegisterPickPointDbRepositories(this IServiceCollection services)
        {
            services.AddTransient<ParcelTerminalRepository>();
            services.AddTransient<ParcelRepository>();
        }
    }
}
