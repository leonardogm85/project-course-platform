using CoursePlatform.Identity.Data.Context;
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

        builder.Property(claim => claim.ClaimType)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(claim => claim.ClaimValue)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(claim => claim.CreatedAt)
            .IsRequired();

        builder.Property(claim => claim.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.RoleClaims));
    }
}
