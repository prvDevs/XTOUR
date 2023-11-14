namespace XCRS.Core.Domain.Interfaces.Infrastructure.Repositories.MongoDb
{
    public interface IGenericMongoDbRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(IList<T> entities);
    }
}
