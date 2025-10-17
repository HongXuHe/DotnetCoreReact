using Microsoft.EntityFrameworkCore;
using Server.Application.Contract;
using Server.Core.Entities;

namespace Server.Infrastructure.Implementation;

public class StoreContext:DbContext,IStoreContext
{
    public StoreContext(DbContextOptions<StoreContext> options):base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();
}