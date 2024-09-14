using ClassPoint.Domain;

namespace Classpoint.Domain.Entities.Classes;

public class Class: AuditableEntity
{
    public Guid Id { get; set; }
    public string ClassName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ScheduleDateTime { get; set; }
    public int AvailableSpots { get; set; }
    public int MaxSpots { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}

