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

        builder.Property(claim => claim.Submenu)
            .HasColumnName("SubmenuId")
            .HasConversion<SubmenuConverter>();

        builder.HasOne(claim => claim.Submenu)
            .WithMany()
            .IsRequired();

        builder.Property(claim => claim.Access)
            .HasColumnName("AccessId")
            .HasConversion<AccessConverter>();

        builder.HasOne(claim => claim.Access)
            .WithMany()
            .IsRequired();

        builder.Property(claim => claim.CreatedAt)
            .IsRequired();

        builder.Property(claim => claim.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.RoleClaims));
    }
}
