using System;

namespace Cirl.Connector.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cirl = new RealtimeLogger("https://localhost:44309/log", "123abc", Guid.Parse("787281ed-75cf-44e0-bad1-795c5a9d2336"));
            cirl.Log(LogSeverity.Critical, "testing").Wait();
        }
    }
}
