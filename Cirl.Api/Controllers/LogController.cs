using AutoMapper;
using Cirl.Api.Models;
using Cirl.Application;
using Cirl.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cirl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public LogController(IMapper mapper, ILogService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        [HttpGet]
        public Task<IEnumerable<LogEntry>> Get(long start)
            => _logService.GetLogs(start);

        [HttpPost]
        public async Task Post([FromBody] LogEntryModel model)
        {
            var log = _mapper.Map<LogEntry>(model);
            log.Id = 0;
            log.Date = DateTimeOffset.UtcNow;

            await _logService.AddLog(log, model.Key);
        }
    }
}
