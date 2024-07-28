using CoursePlatform.Core.Data;
using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Identity.Data.Converters;
using CoursePlatform.Identity.Data.Extensions;
using CoursePlatform.Identity.Data.Mappings;
using CoursePlatform.Identity.Domain.Entities;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;

namespace CoursePlatform.Identity.Data.Context;

public class IdentityContext : DbContext, IUnitOfWork
{
    private readonly PersonalDataConverter _personalDataConverter;
    private readonly IMediatorHandler _mediatorHandler;

    public DbSet<Role> Roles { get; } = null!;
    public DbSet<RoleClaim> RoleClaims { get; } = null!;
    public DbSet<User> Users { get; } = null!;
    public DbSet<UserClaim> UserClaims { get; } = null!;
    public DbSet<UserLogin> UserLogins { get; } = null!;
    public DbSet<UserRole> UserRoles { get; } = null!;
    public DbSet<UserToken> UserTokens { get; } = null!;
    public DbSet<Menu> Menus { get; } = null!;
    public DbSet<Submenu> Submenus { get; } = null!;
    public DbSet<Access> Accesses { get; } = null!;

    public IdentityContext(DbContextOptions<IdentityContext> options, PersonalDataConverter personalDataConverter, IMediatorHandler mediatorHandler) : base(options)
    {
        _personalDataConverter = personalDataConverter;
        _mediatorHandler = mediatorHandler;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping(_personalDataConverter));
        modelBuilder.ApplyConfiguration(new UserClaimMapping());
        modelBuilder.ApplyConfiguration(new UserLoginMapping());
        modelBuilder.ApplyConfiguration(new UserRoleMapping());
        modelBuilder.ApplyConfiguration(new UserTokenMapping());
        modelBuilder.ApplyConfiguration(new RoleMapping());
        modelBuilder.ApplyConfiguration(new RoleClaimMapping());
        modelBuilder.ApplyConfiguration(new MenuMapping());
        modelBuilder.ApplyConfiguration(new SubmenuMapping());
        modelBuilder.ApplyConfiguration(new AccessMapping());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var entitiesSaved = await SaveChangesAsync(cancellationToken) > 0;

        if (entitiesSaved)
        {
            await _mediatorHandler.PublishEventsAsync(this, cancellationToken);
        }

        return entitiesSaved;
    }
}
