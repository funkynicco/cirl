using Cirl.Application.Services;
using Cirl.Infrastructure.Internal;
using Cirl.Infrastructure.Internal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Infrastructure
{
    public static class InfrastructureServicesConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("Default");

            //services.AddDbContext<CirlDbContext>(b => b.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddDbContextFactory<CirlDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddTransient<ILogRepository, LogRepository>();
        }
    }
}
