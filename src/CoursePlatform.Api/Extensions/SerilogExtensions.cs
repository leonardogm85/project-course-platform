using Serilog;

namespace CoursePlatform.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static IHostBuilder ConfigureCustomSerilog(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            return host;
        }

        public static IApplicationBuilder UseCustomSerilog(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }
    }
}
