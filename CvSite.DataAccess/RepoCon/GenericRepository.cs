using System.Linq.Expressions;
using CvSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CvSite.DataAccess.RepoCon;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly CvSiteDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(CvSiteDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task AddObjectAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void RemoveObject(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public async Task<T?> GetObjectByIdAsync(int id)
    {
        var fValue = _dbSet.FindAsync(id);
        return await fValue;
    }

    public void UpdateObject(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAllObject()
    {
        return await _dbSet.ToListAsync();
    }

    public IQueryable<T> GetAllObjectWithQuery(Expression<Func<T, bool>> query)
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

}