using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cirl.Application.Services
{
    public interface ILogService
    {
        Task<IEnumerable<LogEntry>> GetLogs(long start);

        Task AddLog(LogEntry log, string key = null);
    }
}
