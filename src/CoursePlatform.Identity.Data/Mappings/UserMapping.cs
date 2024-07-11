using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Data.Converters;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    private readonly PersonalDataConverter _personalDataConverter;

    public UserMapping(PersonalDataConverter personalDataConverter)
    {
        _personalDataConverter = personalDataConverter;
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasMaxLength(2500)
            .IsUnicode()
            .IsRequired()
            .HasConversion(_personalDataConverter);

        builder.Property(user => user.Email)
            .HasMaxLength(2500)
            .IsUnicode()
            .IsRequired()
            .HasConversion(_personalDataConverter);

        builder.Property(user => user.PhoneNumber)
            .HasMaxLength(200)
            .IsUnicode()
            .IsRequired()
            .HasConversion(_personalDataConverter);

        builder.Property(user => user.EmailConfirmed)
            .IsRequired();

        builder.Property(user => user.PhoneNumberConfirmed)
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(user => user.SecurityStamp)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(user => user.TwoFactorEnabled)
            .IsRequired();

        builder.Property(user => user.LockoutEnd)
            .IsRequired(false);

        builder.Property(user => user.LockoutEnabled)
            .IsRequired();

        builder.Property(user => user.AccessFailedCount)
            .IsRequired();

        builder.Property(user => user.Administrator)
            .IsRequired();

        builder.Property(user => user.UpdatedAt)
            .IsRequired();

        builder.Property(user => user.CreatedAt)
            .IsRequired();

        builder.Property(user => user.UpdatedBy)
            .IsRequired();

        builder.Property(user => user.CreatedBy)
            .IsRequired();

        builder.Property(user => user.Active)
            .IsRequired();

        builder.Property(user => user.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity<UserRole>();

        builder.HasMany(user => user.Claims)
            .WithOne(claim => claim.User);

        builder.HasMany(user => user.Logins)
            .WithOne(login => login.User);

        builder.HasMany(user => user.Tokens)
            .WithOne(token => token.User);

        builder.ToTable(nameof(IdentityContext.Users));
    }
}
