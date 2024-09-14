using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClassPoint.Domain.Entities;

namespace Classpoint.Infrastructure.Persistance.Configurations.User;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(m => m.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(m => m.LastName).HasMaxLength(50).IsRequired();
    }
}
