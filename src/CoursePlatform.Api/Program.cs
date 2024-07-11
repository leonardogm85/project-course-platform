using CoursePlatform.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ??
    throw new InvalidOperationException("Connection string not found.");

var cultureName = builder.Configuration.GetValue<string>("AppSettings:CultureName")
    ??
    throw new InvalidOperationException("Culture name not found.");

builder.Services.AddControllers();

builder.Services.AddCore();

builder.Services.AddDataProtection();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

app.UseHsts();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = [new(cultureName)],
    SupportedUICultures = [new(cultureName)],
    DefaultRequestCulture = new(cultureName)
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
