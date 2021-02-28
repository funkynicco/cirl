using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Application
{
    public class LogCollection
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public ICollection<LogApplication> Applications { get; set; }
    }
}
