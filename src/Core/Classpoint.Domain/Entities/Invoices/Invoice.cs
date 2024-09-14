using Classpoint.Domain.Entities.Classes;
using ClassPoint.Domain.Entities;

namespace Classpoint.Domain.Entities.Invoices;

public class Invoice
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; }
    public string DiscountCode { get; set; }
    public DateTime PaymentDateTime { get; set; }
    public string InvoiceStatus { get; set; }

    public int UserId { get; set; }
    public AppUser User { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}

