using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClassPoint.Domain.Entities;

namespace Classpoint.Infrastructure.Persistance.Configurations.User;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
    }
}
