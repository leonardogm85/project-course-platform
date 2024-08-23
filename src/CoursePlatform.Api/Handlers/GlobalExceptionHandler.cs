using System.Diagnostics;

using Microsoft.AspNetCore.Diagnostics;

namespace CoursePlatform.Api.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<GlobalExceptionHandler> logger)
        {
            _problemDetailsService = problemDetailsService;
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var traceId = Activity.Current?.Id
                ??
                httpContext.TraceIdentifier;

            var machineName = Environment.MachineName;

            _logger.LogError(
                exception,
                "An error occurred while processing the request on the machine {MachineName}. TraceId: {TraceId}",
                machineName,
                traceId);

            return await _problemDetailsService.TryWriteAsync(new()
            {
                HttpContext = httpContext,
                ProblemDetails =
                {
                    Extensions = new Dictionary<string, object?>
                    {
                        { "traceId", traceId }
                    }
                },
                Exception = exception
            });
        }
    }
}
