using CoursePlatform.Api.Settings;

namespace CoursePlatform.Api.Extensions;

public static class CultureExtensions
{
    public static IApplicationBuilder UseCustomCulture(this IApplicationBuilder app, IConfiguration configuration)
    {
        var cultureSettings = configuration.GetSection(nameof(CultureSettings)).Get<CultureSettings>()
            ??
            throw new InvalidOperationException("Culture settings not found.");

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            SupportedCultures = [new(cultureSettings.Name)],
            SupportedUICultures = [new(cultureSettings.Name)],
            DefaultRequestCulture = new(cultureSettings.Name)
        });

        return app;
    }
}
