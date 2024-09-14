using ClassPoint.Domain.Entities;

namespace Classpoint.Domain.Entities.Notifications;

public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string NotificationType { get; set; }
    public DateTime SentAt { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; }
}
