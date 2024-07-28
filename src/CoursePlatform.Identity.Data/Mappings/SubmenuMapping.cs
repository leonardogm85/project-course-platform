using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.Extensions;
using CoursePlatform.Identity.Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePlatform.Identity.Data.Mappings;

public class SubmenuMapping : IEntityTypeConfiguration<Submenu>
{
    public void Configure(EntityTypeBuilder<Submenu> builder)
    {
        builder.HasKey(submenu => submenu.Id);

        builder.Property(submenu => submenu.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.Property(submenu => submenu.Order)
            .IsRequired();

        builder.Property(submenu => submenu.Route)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();

        builder.HasOne(submenu => submenu.Menu)
            .WithMany(menu => menu.Submenus)
            .HasForeignKey(submenu => submenu.MenuId)
            .IsRequired();

        builder.ToTable(nameof(IdentityContext.Submenus));

        var submenus = EnumExtensions
            .GetAll<Domain.Enums.Submenu>()
            .Select(submenu => (Submenu)submenu);

        builder.HasData(submenus);
    }
}
