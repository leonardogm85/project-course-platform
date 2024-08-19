using CoursePlatform.Identity.Application.Commands.Handlers;
using CoursePlatform.Identity.Application.Commands.Roles;
using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Data.Converters;
using CoursePlatform.Identity.Data.Repositories;
using CoursePlatform.Identity.Data.Settings;
using CoursePlatform.Identity.Domain.Interfaces.Repositories;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoursePlatform.Identity.Application.Extensions;

public static class ApplicationExtensions
{
    public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ??
            throw new InvalidOperationException("Connection string not found.");

        services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRequestHandler<AddRoleCommand, bool>, RoleCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateRoleCommand, bool>, RoleCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveRoleCommand, bool>, RoleCommandHandler>();

        services.AddScoped<PersonalDataConverter>();

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
