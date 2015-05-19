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
        static void Main()
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection {
                { "configType", "INLINE" }
            });

            var log = LogManager.GetLogger<ApiUsage>();

            log.Debug(w => w("User registered"));
            log.Info(w => w("User registered"));
            log.Warn(w => w("User registered"));
            log.Error(w => w("User registered"));

            log.EventInfo(new { name = "test" });
            log.EventInfo(new UserRegistered { Name = "test" });

            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                log.Info("Message " + i);
                Thread.Sleep(random.Next(250));
            }

            Console.ReadLine();
        }
    }

    public class ApiUsage { }

    public class UserRegistered
    {
        public string Name { get; set; }
    }

    public static class LogExtensions
    {
        public static ILog EventDebug(this ILog log, object @event)
        {
            log.Debug(w => w("[{0}] -> {1}", @event.GetType(), JsonConvert.SerializeObject(@event)));
            return log;
        }

        public static ILog EventInfo(this ILog log, object @event)
        {
            log.Info(w => w("[{0}] -> {1}", @event.GetType(), JsonConvert.SerializeObject(@event)));
            return log;
        }
    }
}
