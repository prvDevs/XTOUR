using System.Linq.Expressions;

namespace XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        Task<IEnumerable<T>> FindAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void DeleteFlag(T entity);
        void DeletePermanently(T entity);
        Task<int> CountAsync(ISpecification<T> spec);

        #region Bulk
        Task BulkInsertAsync(List<T> items);
        Task BulkUpdateAsync(List<T> items);
        Task BulkDeleteFlagAsync(List<T> items);
        Task BulkDeletePermanentlyAsync(List<T> items);
        //Task BulkInsertOrUpdateAsync(List<T> items);
        //Task BulkInsertOrUpdateOrDeleteAsync(List<T> items); 
        #endregion
    }
}
