using System.Linq.Expressions;
using Server.Core.Entities;

namespace Server.Application.Contract;

public interface IBaseRepo<T> where T:BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteByIdAsync(string id);
    Task<T> GetByIdAsync(string id);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetListQueryable();
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate); 
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}