using CoursePlatform.Api.Extensions;
using CoursePlatform.Api.Handlers;
using CoursePlatform.Core.Extensions;
using CoursePlatform.Identity.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDataProtection();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddVersioning();
builder.Services.AddDocumentation(builder.Configuration);

builder.Services.AddCoreContext();
builder.Services.AddIdentityContext(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDocumentation(builder.Configuration);
}

app.UseCulture(builder.Configuration);

app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePages();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
