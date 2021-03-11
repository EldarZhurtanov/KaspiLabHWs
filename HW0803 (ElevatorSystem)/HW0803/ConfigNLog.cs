using NLog;
using NLog.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803
{
    public static class ConfigurateNLog
    {
        public static void Confugurate()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole") { Layout = Layout.FromString("${level} | ${date} | ${message}") };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }
    }
}
