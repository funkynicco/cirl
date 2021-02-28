using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Application
{
    public class LogApplication
    {
        public Guid Id { get; set; }

        public Guid CollectionId { get; set; }

        public LogCollection Collection { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public ICollection<LogEntry> Logs { get; set; }
    }
}
