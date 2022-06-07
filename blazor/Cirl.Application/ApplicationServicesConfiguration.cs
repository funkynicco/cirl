using Cirl.Application.Internal.Services;
using Cirl.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Application
{
    public static class ApplicationServicesConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ILogService, LogService>();
        }
    }
}
