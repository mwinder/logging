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

            var basicLog = LogManager.GetLogger<Program>();

            basicLog.Debug(w => w("Example DEBUG"));
            basicLog.Info(w => w("Example INFO"));
            basicLog.Warn(w => w("Example WARN"));
            basicLog.Error(w => w("Example ERROR"));

            var userRegistered = new UserRegistered { Id = 23, Name = "Test User" };

            var eventsLog = LogManager.GetLogger<Events>();
            eventsLog
                .EventInfo(new { name = "test" })
                .EventInfo(new UserRegistered { Name = "test" })
                .EventDebug(new { Id = 23, Name = "Matthew" })
                .EventInfo(userRegistered);

            var log = LogManager.GetLogger<Random>();
            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                log.Info("Message " + i);
                Thread.Sleep(random.Next(250));
            }

            Console.ReadLine();
        }
    }

    public abstract class Events { }

    public class UserRegistered
    {
        public int Id { get; set; }
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
