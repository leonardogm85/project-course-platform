using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Extensions;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class MenuItemMapping : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(menuItem => menuItem.Id);

        builder.Property(menuItem => menuItem.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.Property(menuItem => menuItem.Order)
            .IsRequired();

        builder.Property(menuItem => menuItem.Route)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.HasOne(menuItem => menuItem.Menu)
            .WithMany(menu => menu.MenuItems)
            .HasForeignKey(menuItem => menuItem.MenuId)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.MenuItems));

        var menuItems = EnumExtensions
            .GetAll<Domain.Enums.MenuItem>()
            .Select(menuItem => (MenuItem)menuItem);

        builder.HasData(menuItems);
    }
}
