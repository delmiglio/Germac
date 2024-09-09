using MediatR;
using Serilog;

namespace Germac.Application.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse>(ILogger logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest, new()
    {
        private readonly ILogger _logger = logger.ForContext("RequestType", typeof(TRequest).Name);

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.Information("Starting request: {RequestName} at {DateTime}", requestName, DateTime.UtcNow);

            try
            {
                var response = await next();
                _logger.Information("Completed request: {RequestName} at {DateTime}", requestName, DateTime.UtcNow);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Request {RequestName} failed at {DateTime}", requestName, DateTime.UtcNow);
                throw;
            }
        }
    }
}
