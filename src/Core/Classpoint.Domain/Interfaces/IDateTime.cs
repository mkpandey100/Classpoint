namespace ClassPoint.Domain.Interfaces;

public interface IDateTime : IScopedService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}