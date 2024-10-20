using System.Linq.Expressions;
using HotellBooking.Application.Interfaces;
using HotellBooking.Persitence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Persitence.EfRepositories;

public class EfGenericRepository<T> : IEfGenericRepository<T> where T : class, new()
{
    protected readonly HotelBookingDbContext _context;
    
    public EfGenericRepository(HotelBookingDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
        
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
        
    }
    
    public async Task<List<T>> AddRangeAsync(List<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<T> UpdateAsync(T entity)
    {
         _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    
    
    public async Task<bool> DeleteRangeAsync(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await _context.Set<T>().AnyAsync(predicate);
        return result;
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await _context.Set<T>().CountAsync(predicate);
        return result;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);
        return result;
    }
}