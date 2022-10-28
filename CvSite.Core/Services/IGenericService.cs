using System.Linq.Expressions;

namespace CvSite.Core.Services;

public interface IGenericService<T> where T : class
{
    Task AddObjectAsync(T entity);
    void RemoveObject(T entity);
    Task<T?> GetObjectByIdAsync(int id);
    void UpdateObject(T entity);
    Task<IEnumerable<T>> GetAllObject();
    IQueryable<T> GetAllObjectWithQuery(Expression<Func<T,bool>> query);
    //List<T> ReturnAllValuesService();
}