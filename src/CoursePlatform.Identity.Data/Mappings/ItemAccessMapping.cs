using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Extensions;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class ItemAccessMapping : IEntityTypeConfiguration<ItemAccess>
{
    public void Configure(EntityTypeBuilder<ItemAccess> builder)
    {
        builder.HasKey(itemAccess => itemAccess.Id);

        builder.Property(itemAccess => itemAccess.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.ItemAccesses));

        var itemAccesses = EnumExtensions
            .GetAll<Domain.Enums.ItemAccess>()
            .Select(itemAccess => (ItemAccess)itemAccess);

        builder.HasData(itemAccesses);
    }
}
