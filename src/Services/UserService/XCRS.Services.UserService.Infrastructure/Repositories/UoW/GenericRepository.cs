using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace XCRS.Services.UserService.Infrastructure.Repositories.UoW
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> FindAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public virtual async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public virtual void Add(T entity)
        {
            var createdAtProperty = typeof(T).GetProperty("CreatedAt");
            createdAtProperty?.SetValue(entity, DateTime.Now);

            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            var updatedAtProperty = typeof(T).GetProperty("UpdatedAt");
            updatedAtProperty?.SetValue(entity, DateTime.Now);

            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteFlag(T entity)
        {
            var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
            var deletedAtProperty = typeof(T).GetProperty("DeletedAt");

            isDeletedProperty?.SetValue(entity, true);

            deletedAtProperty?.SetValue(entity, DateTime.Now);

            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeletePermanently(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return QueryEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        #region bulk
        public virtual async Task BulkInsertAsync(List<T> items)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                var createdAtProperty = typeof(T).GetProperty("CreatedAt"); ;
                if (createdAtProperty != null)
                {
                    foreach (var item in items)
                        createdAtProperty.SetValue(item, DateTime.Now);
                }

                await _dbContext.BulkInsertAsync(items);

                transaction.Commit();
            }
        }

        public virtual async Task BulkUpdateAsync(List<T> items)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            var updatedAtProperty = typeof(T).GetProperty("UpdatedAt"); ;
            if (updatedAtProperty != null)
            {
                foreach (var item in items)
                    updatedAtProperty.SetValue(item, DateTime.Now);
            }

            await _dbContext.BulkUpdateAsync(items);

            transaction.Commit();
        }

        public virtual async Task BulkDeleteFlagAsync(List<T> items)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                var deletedAtProperty = typeof(T).GetProperty("DeletedAt");
                var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
                if (deletedAtProperty != null && isDeletedProperty != null)
                {
                    foreach (var item in items)
                    {
                        deletedAtProperty.SetValue(item, DateTime.Now);
                        isDeletedProperty.SetValue(item, true);
                    }
                }

                await _dbContext.BulkUpdateAsync(items);

                transaction.Commit();
            }
        }

        public virtual async Task BulkDeletePermanentlyAsync(List<T> items)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await _dbContext.BulkDeleteAsync(items);

                transaction.Commit();
            }
        }

        //public virtual async Task BulkInsertOrUpdateAsync(List<T> items)
        //{
        //    using (var transaction = _dbContext.Database.BeginTransaction())
        //    {
        //        _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        //        await _dbContext.BulkInsertOrUpdateAsync(items);

        //        transaction.Commit();
        //    }
        //}

        //public virtual async Task BulkInsertOrUpdateOrDeleteAsync(List<T> items)
        //{
        //    using (var transaction = _dbContext.Database.BeginTransaction())
        //    {
        //        _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        //        await _dbContext.BulkInsertOrUpdateOrDeleteAsync(items);

        //        transaction.Commit();
        //    }
        //}
        #endregion

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    #region SpecificationEvaluator
    public class QueryEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.PagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }
    }
    #endregion
}
