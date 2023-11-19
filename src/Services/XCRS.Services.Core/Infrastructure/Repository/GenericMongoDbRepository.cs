using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using XCRS.Core.Entities.UserService.Core.Entities;
using XCRS.Services.Core.Application.Customizations.Attributes;
using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Contexts;
using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Repository;

namespace XCRS.Services.Core.Infrastructure.Repository
{
    public class GenericMongoDbRepository<TDocument> : IGenericMongoDbRepository<TDocument>
    where TDocument : IBaseEntity
    {
        protected readonly IMongoDatabase _context;
        private readonly IMongoCollection<TDocument> _collection;

        public GenericMongoDbRepository(IMongoContext context)
        {
            _context = context.Database;
            _collection = _context.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string? GetCollectionName(Type documentType)
        {
            string r = string.Empty;
            try
            {
                var collection = (BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).First();
                r = collection.CollectionName;
            }
            catch (Exception){ 
            }

            return r;
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true).ConfigureAwait(false)).ToEnumerable();
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual TDocument FindById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq("_id", objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq("_id", objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }


        public virtual void InsertOne(TDocument document)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            createdAtProperty?.SetValue(document, DateTime.UtcNow);

            _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            createdAtProperty?.SetValue(document, DateTime.UtcNow);

            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void InsertMany(ICollection<TDocument> documents, bool genCreatedAt = false)
        {
            if (genCreatedAt) {
                var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
                for (int i = 0; i < documents.Count; i++)
                {
                    createdAtProperty?.SetValue(documents.ElementAt(i), DateTime.UtcNow);
                }
            }
            
            _collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents, bool genCreatedAt = false)
        {
            if (genCreatedAt)
            {
                var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
                for (int i = 0; i < documents.Count; i++)
                {
                    createdAtProperty?.SetValue(documents.ElementAt(i), DateTime.UtcNow);
                }

            }

            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            var updatedAtProperty = typeof(TDocument).GetProperty("UpdatedAt");
            updatedAtProperty?.SetValue(document, DateTime.UtcNow);

            var filter = Builders<TDocument>.Filter.Eq("_id", document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var updatedAtProperty = typeof(TDocument).GetProperty("UpdatedAt");
            updatedAtProperty?.SetValue(document, DateTime.UtcNow);

            var filter = Builders<TDocument>.Filter.Eq("_id", document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOneFlag(TDocument document)
        {
            var isDeletedProperty = typeof(TDocument).GetProperty("IsDeleted");
            isDeletedProperty?.SetValue(document, DateTime.UtcNow);

            var filter = Builders<TDocument>.Filter.Eq("_id", document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task DeleteOneFlagAsync(TDocument document)
        {
            var isDeletedProperty = typeof(TDocument).GetProperty("IsDeleted");
            isDeletedProperty?.SetValue(document, DateTime.UtcNow);

            var filter = Builders<TDocument>.Filter.Eq("_id", document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }


        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq("_id", objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq("_id", objectId);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }
    }
}