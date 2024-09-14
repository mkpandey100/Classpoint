using ClassPoint.Domain.Interfaces;

namespace ClassPoint.Infrastructure.Persistance.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}