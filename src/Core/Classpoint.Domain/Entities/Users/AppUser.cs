using Classpoint.Domain.Entities.Classes;
using Classpoint.Domain.Entities.Invoices;
using Classpoint.Domain.Entities.Notifications;
using Microsoft.AspNetCore.Identity;

namespace ClassPoint.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return (FirstName + " " + LastName).Trim(); } }


        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}