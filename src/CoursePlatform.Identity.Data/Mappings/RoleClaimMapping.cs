using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Data.Converters;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(claim => claim.Id);

        builder.HasOne(claim => claim.Role)
            .WithMany(user => user.Claims)
            .HasForeignKey(claim => claim.RoleId)
            .IsRequired();

        builder.HasOne(claim => claim.ClaimType)
            .WithMany()
            .IsRequired();

        builder.Property(claim => claim.ClaimType)
            .HasConversion<MenuItemConverter>();

        builder.HasOne(claim => claim.ClaimValue)
            .WithMany()
            .IsRequired();

        builder.Property(claim => claim.ClaimValue)
            .HasConversion<ItemAccessConverter>();

        builder.Property(claim => claim.CreatedAt)
            .IsRequired();

        builder.Property(claim => claim.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.RoleClaims));
    }
}
