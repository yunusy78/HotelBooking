using System.Linq.Expressions;

namespace HotellBooking.Application.Interfaces;

public interface IEfGenericRepository<T> where T : class
{

    Task<List<T>> GetAllAsync();
    
    Task<T> GetByIdAsync(int id);
    
    Task<T> AddAsync(T entity);
    
    Task<List<T>> AddRangeAsync(List<T> entities);
    
    Task<T> UpdateAsync(T entity);
    
    Task<bool> DeleteAsync(T entity);
    
    Task<bool> DeleteRangeAsync(List<T> entities);
    
    Task<bool> SaveAsync();
    
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

}