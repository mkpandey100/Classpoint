using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Classpoint.Domain.Entities.Notifications;

namespace Classpoint.Infrastructure.Persistance.Configurations.Notifications;


public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(m => m.Id);
    }
}