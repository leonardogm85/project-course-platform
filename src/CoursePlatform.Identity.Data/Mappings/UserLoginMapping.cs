using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(login => login.Id);

        builder.HasOne(login => login.User)
            .WithMany(user => user.Logins)
            .HasForeignKey(login => login.UserId)
            .IsRequired();

        builder.Property(token => token.LoginProvider)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(token => token.ProviderKey)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(login => login.CreatedAt)
            .IsRequired();

        builder.Property(login => login.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.UserLogins));
    }
}
