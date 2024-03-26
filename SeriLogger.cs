using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using Serilog.Core;

namespace PizzaPlaceSalesAPI
{
    public class SeriLogger
    {
        private readonly Logger _logger = new LoggerConfiguration()
                                    .WriteTo.File(new JsonFormatter(),
                                                  "Logs/pps-logs.json",
                                                  restrictedToMinimumLevel: LogEventLevel.Warning)
                                    .WriteTo.File("Logs/pps-logs.logs",
                                                  rollingInterval: RollingInterval.Day)
                                    .MinimumLevel.Debug()
                                    .CreateLogger();
        public Logger GetLogger() => _logger;
    }
}
