using Cirl.Application;
using Cirl.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cirl.Infrastructure.Internal.Repositories
{
    internal class LogRepository : ILogRepository
    {
        private readonly IDbContextFactory<CirlDbContext> _factory;

        public LogRepository(IDbContextFactory<CirlDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<LogEntry>> GetLogs(long start)
        {
            using var context = _factory.CreateDbContext();
            return await context.Logs
                .Where(a => a.Id >= start)
                .OrderByDescending(a => a.Id)
                .Take(1000)
                .Include(a => a.Application)
                .ThenInclude(a => a.Collection)
                .ToListAsync();
        }

        public async Task AddLog(LogEntry log, string key = null)
        {
            using var context = _factory.CreateDbContext();

            if (key != null)
            {
                var application = await context.Applications
                    .Include(a => a.Collection)
                    .FirstOrDefaultAsync(a => a.Id == log.ApplicationId);

                if (application == null)
                {
                    throw new ArgumentException($"There is no application with the provided id: {log.ApplicationId}");
                }

                // match key against application.Key if set, otherwise it matches against its own value
                if (key != (application.Key ?? key))
                {
                    throw new ArgumentException($"The key is not valid.");
                }

                if (key != (application.Collection.Key ?? key))
                {
                    throw new ArgumentException($"The key is not valid.");
                }
            }

            context.Logs.Add(log);
            await context.SaveChangesAsync();
        }
    }
}
