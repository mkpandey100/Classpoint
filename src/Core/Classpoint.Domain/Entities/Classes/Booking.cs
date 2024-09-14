using Classpoint.Domain.Entities.Invoices;
using ClassPoint.Domain.Entities;

namespace Classpoint.Domain.Entities.Classes;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime BookingDateTime { get; set; }
    public string Status { get; set; }
    public string PaymentStatus { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; }

    public Guid ClassId { get; set; }
    public Class Class { get; set; }

    public Guid? InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}
