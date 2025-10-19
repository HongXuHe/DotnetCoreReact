using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Application.Contract;

public interface IStoreContext
{
    DbSet<Activity> Activities { get; }
    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<T> Set<T>() where T : class;
}