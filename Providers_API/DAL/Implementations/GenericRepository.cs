using Microsoft.EntityFrameworkCore;
using Providers_API.DAL.DBContext;
using Providers_API.DAL.Definitions;
using System.Linq.Expressions;

namespace Providers_API.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ProvidersPlatformContext _dbContext;
        
        public GenericRepository(ProvidersPlatformContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var query = (filter == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filter).AsQueryable();
                return query;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Select(Expression<Func<T, bool>> filter)
        {
            try
            {
                T onething = await _dbContext.Set<T>().FirstOrDefaultAsync(filter);
                return onething;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
