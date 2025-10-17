using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Application.Contract;

public interface IStoreContext
{
    DbSet<Product> Products { get; }
}