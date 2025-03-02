using System.Reflection;

using Asp.Versioning.ApiExplorer;

using CoursePlatform.Api.Settings;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoursePlatform.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        services.Configure<InfoSettings>(configuration.GetSection(nameof(InfoSettings)));

        services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                BearerFormat = "JWT",
                Description = "Authorization header using the Bearer scheme (JWT). Example: `Authorization: Bearer {token}`",
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Reference = new()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            options.AddSecurityRequirement(new()
            {
                { securityScheme, [] }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            var descriptions = ((WebApplication)app).DescribeApiVersions();

            foreach (var description in descriptions)
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName.ToUpperInvariant();

                options.SwaggerEndpoint(url, name);
            }
        });

        return app;
    }

    private class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IOptions<InfoSettings> _options;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IOptions<InfoSettings> options)
        {
            _provider = provider;
            _options = options;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoByApiVersion(description));
            }
        }

        private OpenApiInfo CreateInfoByApiVersion(ApiVersionDescription description)
        {
            var infoSettings = _options.Value
                ??
                throw new InvalidOperationException("Info settings not found.");

            var info = new OpenApiInfo
            {
                Title = infoSettings.Title,
                Version = description.ApiVersion.ToString(),
                Description = infoSettings.Description,
                Contact = new()
                {
                    Name = infoSettings.Contact.Name,
                    Url = new(infoSettings.Contact.Url)
                },
                License = new()
                {
                    Name = infoSettings.License.Name,
                    Url = new(infoSettings.License.Url)
                }
            };

            return info;
        }
    }
}
