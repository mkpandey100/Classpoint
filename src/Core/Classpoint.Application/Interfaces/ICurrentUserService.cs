using ClassPoint.Domain.Interfaces;

namespace ClassPoint.Application.Interfaces;

public interface ICurrentUserService : IScopedService
{
    Guid UserId { get; }
    string UserName { get; }
    string FullName { get; }
    string Role { get; }
}