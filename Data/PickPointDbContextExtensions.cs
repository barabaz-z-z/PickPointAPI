using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class PickPointDbContextExtensions
    {
        public static void AddPickPointDbContext(this IServiceCollection services, string conectionString)
        {
            services.AddDbContext<PickPointDbContext>(options => options.UseNpgsql(conectionString));
        }
    }
}
