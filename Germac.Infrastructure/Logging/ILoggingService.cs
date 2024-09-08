namespace Germac.Infrastructure.Logging
{
    public interface ILoggingService
    {
        void LogInfo(string message, params object[] args);
        void LogError(string message, Exception exception);
    }
}

