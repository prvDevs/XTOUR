﻿using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Linq.Expressions;
using XCRS.Core.Entities.UserService.Core.Entities;
using XCRS.Services.Core.Application.Customizations.Attributes;
using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Repository;
using XCRS.Services.Core.Domain.Settings;

namespace XCRS.Services.Core.Infrastructure.Repository
{
    public class GenericMongoDbRepository<TDocument> : IGenericMongoDbRepository<TDocument>
    where TDocument : IBaseEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        public GenericMongoDbRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
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
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }


        public virtual void InsertOne(TDocument document)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            createdAtProperty?.SetValue(document, DateTime.Now);

            _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            createdAtProperty?.SetValue(document, DateTime.Now);

            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            for (int i = 0; i < documents.Count; i++) {
                createdAtProperty?.SetValue(documents.ElementAt(i), DateTime.Now);
            }
            _collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            var createdAtProperty = typeof(TDocument).GetProperty("CreatedAt");
            for (int i = 0; i < documents.Count; i++)
            {
                createdAtProperty?.SetValue(documents.ElementAt(i), DateTime.Now);
            }


            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
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
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
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