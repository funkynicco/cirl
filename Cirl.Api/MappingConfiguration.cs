using AutoMapper;
using Cirl.Api.Models;
using Cirl.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cirl.Api
{
    public static class MappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<LogEntry, LogEntryModel>()
                .ReverseMap();
        }
    }
}
