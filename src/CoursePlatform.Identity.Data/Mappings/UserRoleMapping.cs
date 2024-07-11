using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(userRole => userRole.Id);

        builder.HasOne(userRole => userRole.Role)
            .WithMany()
            .HasForeignKey(userRole => userRole.RoleId)
            .IsRequired();

        builder.HasOne(userRole => userRole.User)
            .WithMany()
            .HasForeignKey(userRole => userRole.UserId)
            .IsRequired();

        builder.Property(userRole => userRole.CreatedAt)
            .IsRequired();

        builder.Property(userRole => userRole.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.UserRoles));
    }
}
