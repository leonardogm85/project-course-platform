using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Extensions;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class AccessMapping : IEntityTypeConfiguration<Access>
{
    public void Configure(EntityTypeBuilder<Access> builder)
    {
        builder.HasKey(access => access.Id);

        builder.Property(access => access.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.Accesses));

        var accesses = EnumExtensions
            .GetAll<Domain.Enums.Access>()
            .Select(access => (Access)access);

        builder.HasData(accesses);
    }
}
