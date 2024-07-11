using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class UserTokenMapping : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(token => token.Id);

        builder.HasOne(token => token.User)
            .WithMany(user => user.Tokens)
            .HasForeignKey(token => token.UserId)
            .IsRequired();

        builder.Property(token => token.LoginProvider)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(token => token.TokenName)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(token => token.TokenValue)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

        builder.Property(token => token.CreatedAt)
            .IsRequired();

        builder.Property(token => token.CreatedBy)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.UserTokens));
    }
}
