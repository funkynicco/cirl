using Cirl.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cirl.Api.Models
{
    public class LogEntryModel
    {
        public long Id { get; set; }

        public LogSeverity Severity { get; set; }

        public DateTimeOffset Date { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Message { get; set; }

        public string StackTrace { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }

        [Required]
        public string Key { get; set; }
    }
}
