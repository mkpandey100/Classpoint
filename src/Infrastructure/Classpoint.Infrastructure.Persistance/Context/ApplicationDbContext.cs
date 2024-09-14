using ClassPoint.Application.Interfaces;
using ClassPoint.Domain;
using ClassPoint.Domain.Entities;
using ClassPoint.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClassPoint.Infrastructure.Persistance.Context;

public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime) : IdentityDbContext<AppUser, AppRole, Guid>(options), IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedById = _currentUserService.UserId;
                    entry.Entity.Created = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedById = _currentUserService.UserId;
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var configurationAssembly = Assembly.GetExecutingAssembly();
        var configurationTypes = configurationAssembly.GetTypes()
            .Where(t => t.Namespace == "ClassPoint.Infrastructure.Persistance.Configurations.ApplicationDb"
                        && typeof(IEntityTypeConfiguration<>).IsAssignableFrom(t));

        foreach (var configurationType in configurationTypes)
        {
            dynamic configurationInstance = Activator.CreateInstance(configurationType);
            builder.ApplyConfiguration(configurationInstance);
        }

        base.OnModelCreating(builder);
    }
}