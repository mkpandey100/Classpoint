using ClassPoint.Domain.Entities;
using ClassPoint.Domain.Interfaces;

namespace ClassPoint.Application.Interfaces;

public interface IUserQueryService: IScopedService
{
    Task<bool> CheckPasswordAsync(AppUser user, string password);

    Task<AppUser> FindByIdAsync(Guid userId);

    Task<AppUser> FindByEmailAsync(string email);

    Task<bool> CheckUserAdminAsync(Guid userId);
}