using ClassPoint.Domain.Entities;
using ClassPoint.Domain.Enums;
using ClassPoint.Domain.Interfaces;

namespace ClassPoint.Application.Interfaces;

public interface IUserCommandService: IScopedService
{
    Task<Status> CreateAsync(AppUser appUser, string password, string role);
}