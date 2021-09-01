using System;
using Serilog;

namespace Logging
    
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();

        private Serilog.Core.Logger Log { get; set; }

        private Logger()
        {
            var config = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"Logs\logs.txt", rollingInterval: RollingInterval.Day);
            Log = config.CreateLogger();
        }

        public static Logger Instance { get { return _instance; } }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Critical(string message)
        {
            Log.Fatal(message);
        }

    }
}
