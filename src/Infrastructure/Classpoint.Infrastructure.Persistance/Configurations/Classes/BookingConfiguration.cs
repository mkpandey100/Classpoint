using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Classpoint.Domain.Entities.Classes;

namespace Classpoint.Infrastructure.Persistance.Configurations.Classes;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(m => m.Id);
    }
}
