using System.Linq.Expressions;

namespace Providers_API.DAL.Definitions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Select(Expression<Func<T, bool>> filter);

        Task<T> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
