using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Classpoint.Domain.Entities.Invoices;

namespace Classpoint.Infrastructure.Persistance.Configurations.Invoices;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(m => m.Id);
    }
}
