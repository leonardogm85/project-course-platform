using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Extensions;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class MenuMapping : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(menu => menu.Id);

        builder.Property(menu => menu.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.Property(menu => menu.Order)
            .IsRequired();

        builder.HasMany(menu => menu.Submenus)
            .WithOne(submenu => submenu.Menu);

        builder.ToTable(nameof(IdentityContext.Menus));

        var menus = EnumExtensions
            .GetAll<Domain.Enums.Menu>()
            .Select(menu => (Menu)menu);

        builder.HasData(menus);
    }
}
