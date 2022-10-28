using System.Linq.Expressions;

namespace CvSite.Core.Repositories;

public interface IGenericRepository<T> where  T : class
{
    //update,delete,list,add
    Task AddObjectAsync(T entity);
    void RemoveObject(T entity);
    Task<T?> GetObjectByIdAsync(int id);
    void UpdateObject(T entity);
    Task<IEnumerable<T>> GetAllObject();
    IQueryable<T> GetAllObjectWithQuery(Expression<Func<T,bool>> query);

    //List<T> ReturnAllValues();
}