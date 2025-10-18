using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Application.Contract;

public interface IStoreContext
{
    DbSet<Product> Products { get; }
    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<T> Set<T>() where T : class;
}