using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Log4Net;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection {
                { "configType", "INLINE" }
            });

            var log = LogManager.GetLogger<ApiUsage>();

            log.Debug(w => w("User registered"));
            log.Info(w => w("User registered"));
            log.Warn(w => w("User registered"));
            log.Error(w => w("User registered"));

            log.Event(new { name = "test" });
            log.Event(new UserRegistered { Name = "test" });

            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                log.Info("Message " + i);
                Thread.Sleep(random.Next(250));
            }

            System.Console.ReadLine();
        }
    }

    class ApiUsage { }

    class UserRegistered
    {
        public string Name { get; set; }
    }

    static class LogExtensions
    {
        public static ILog Event(this ILog log, object value)
        {
            log.Info(JsonConvert.SerializeObject(value));
            return log;
        }
    }
}
