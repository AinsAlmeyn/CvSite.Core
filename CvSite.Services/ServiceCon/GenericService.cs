using System.Linq.Expressions;
using CvSite.Core.Repositories;
using CvSite.Core.Services;

namespace CvSite.Services.ServiceCon;

public class GenericService<T> : IGenericService<T> where T: class
{
    private readonly IGenericRepository<T> _repo;

    public GenericService(IGenericRepository<T> repo)
    {
        _repo = repo;
    }
    public async Task AddObjectAsync(T entity)
    {
        await _repo.AddObjectAsync(entity);
    }

    public void RemoveObject(T entity)
    {
        _repo.RemoveObject(entity);
    }

    public async Task<T?> GetObjectByIdAsync(int id)
    {
        return await _repo.GetObjectByIdAsync(id);
    }

    public void UpdateObject(T entity)
    {
        _repo.UpdateObject(entity);
    }

    public async Task<IEnumerable<T>> GetAllObject()
    {
        return await _repo.GetAllObject();
    }

    public IQueryable<T> GetAllObjectWithQuery(Expression<Func<T, bool>> query)
    {
        return _repo.GetAllObjectWithQuery(query);
    }

    public Task<T> FindObject(int id)
    {
        return _repo.FindObject(id);
    }
}