using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Germac.Infrastructure.Logging
{
    public interface ILoggingService
    {
        void LogInfo(string message, params object[] args);
        void LogError(string message, Exception exception);
    }

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
