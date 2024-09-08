using Serilog;

namespace Germac.Infrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInfo(string message, params object[] args)
        {
            _logger.Information(message, args);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }
    }
}
