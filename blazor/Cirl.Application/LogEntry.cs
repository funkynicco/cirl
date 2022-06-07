using Cirl.Connector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Application
{
    public class LogEntry
    {
        public long Id { get; set; }

        public Guid ApplicationId { get; set; }

        public LogApplication Application { get; set; }

        public LogSeverity Severity { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
