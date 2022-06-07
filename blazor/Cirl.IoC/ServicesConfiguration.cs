using Cirl.Application;
using Cirl.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cirl.IoC
{
    public static class ServicesConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            ApplicationServicesConfiguration.Register(services);
            
            InfrastructureServicesConfiguration.Register(services);
        }
    }
}
