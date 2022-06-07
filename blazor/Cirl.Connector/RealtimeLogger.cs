using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cirl.Connector
{
    public class RealtimeLogger
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public string Url { get; }

        public string Key { get; }

        public Guid ApplicationId { get; }

        public RealtimeLogger(string url, string key, Guid applicationId)
        {
            Url = url;
            Key = key;
            ApplicationId = applicationId;
        }

        public async Task Log(LogSeverity severity, string message, string callstack = null)
        {
            var json = JsonSerializer.Serialize(new
            {
                severity,
                message,
                callstack,
                applicationId = ApplicationId,
                key = Key
            }, _jsonSerializerOptions);

            using (var json_content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                await _httpClient.PostAsync(Url, json_content);
            }
        }
    }
}
