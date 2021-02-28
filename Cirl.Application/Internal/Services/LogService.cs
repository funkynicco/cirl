using Cirl.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cirl.Application.Internal.Services
{
    internal class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public Task<IEnumerable<LogEntry>> GetLogs(long start)
            => _logRepository.GetLogs(start);

        public Task AddLog(LogEntry log, string key = null)
            => _logRepository.AddLog(log, key);
    }
}
