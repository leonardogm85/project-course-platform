using CoursePlatform.Api.Extensions;
using CoursePlatform.Core.Extensions;
using CoursePlatform.Identity.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureCustomSerilog();

builder.Services.AddControllers();

builder.Services.AddDataProtection();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddCustomExceptionHandler();
builder.Services.AddCustomVersioning();
builder.Services.AddCustomSwagger(builder.Configuration);

builder.Services.AddCoreContext();
builder.Services.AddIdentityContext(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger(builder.Configuration);
}

app.UseCustomSerilog();
app.UseCustomExceptionHandler();
app.UseCustomCulture(builder.Configuration);

app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
