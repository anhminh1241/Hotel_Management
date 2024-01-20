using System.Linq.Expressions;

namespace HotelManagement.Repositories.Interfaces
{
    public interface IBaseRepo<T,K> where T : class
    { 
       IQueryable<T> FindAll(params Expression<Func<T , object>>[] includes);
       IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
       Task Add(T entity);
       Task Update(T entity, params string[] propertiesToExclue);
       Task Delete(K id);
       Task<T> FindById(K id,  params Expression<Func<T, object>>[] includes);
    
    }
}
