﻿using ClassPoint.Application.Interfaces;
using ClassPoint.Domain.Constants;
using ClassPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClassPoint.Infrastructure.Identity.Extensions
{
    public class UserQueryService(UserManager<AppUser> userManager, IApplicationDbContext context) : IUserQueryService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IApplicationDbContext _context = context;

        /// <summary>
        /// Verify password asynchronously.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(AppUser user, string password) =>
            await _userManager.CheckPasswordAsync(user, password);

        public Task<bool> CheckUserAdminAsync(Guid userId) =>
            _context
                 .Roles
                 .Where(m =>
                         _context
                         .UserRoles
                         .Where(m => m.UserId == userId)
                         .Select(m => m.RoleId)
                         .Contains(m.Id) &&
                         (m.Name == Role.Admin || m.Name == Role.User)
                      )
                 .AnyAsync();

        /// <summary>
        /// Gets user data by email asynchronously.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<AppUser> FindByEmailAsync(string email) =>
            await _userManager.FindByEmailAsync(email);

        /// <summary>
        /// Gets user data by id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppUser> FindByIdAsync(Guid userId) =>
            await _userManager.FindByIdAsync(userId.ToString());
    }
}