using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(role => role.UpdatedAt)
            .IsRequired();

        builder.Property(role => role.CreatedAt)
            .IsRequired();

        builder.Property(role => role.UpdatedBy)
            .IsRequired();

        builder.Property(role => role.CreatedBy)
            .IsRequired();

        builder.Property(role => role.Active)
            .IsRequired();

        builder.Property(role => role.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.HasMany(role => role.Users)
            .WithMany(user => user.Roles)
            .UsingEntity<UserRole>();

        builder.HasMany(role => role.Claims)
            .WithOne(claim => claim.Role);

        builder.ToTable(nameof(IdentityContext.Roles));
    }
}
