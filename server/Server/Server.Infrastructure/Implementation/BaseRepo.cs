using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Server.Application.Contract;
using Server.Core.Entities;

namespace Server.Infrastructure.Implementation;

public class BaseRepo<T> :IBaseRepo<T> where T:BaseEntity
{
    private readonly IStoreContext _context;

    public BaseRepo(IStoreContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;  
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(string id)
    {
        if (_context.Set<T>().Any(x => x.Id == id))
        {
            _context.Set<T>().Remove(await GetByIdAsync(id));
        }
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> GetListQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        if (_context.Set<T>().Any(predicate))
        {
            return  await _context.Set<T>().Where(predicate).ToListAsync();
        }
        return default;
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AnyAsync(predicate);
    }
}