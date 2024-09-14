using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Classpoint.Domain.Entities.Classes;

namespace Classpoint.Infrastructure.Persistance.Configurations.Classes;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(m => m.Id);
    }
}
