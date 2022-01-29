namespace mongodb.repository.Contracts;

using MongoDB.Driver;

public interface IRepository<T> where T : ICollectionItem
{
    ICollectionService<T> CollectionService { get; }
    IMongoCollection<T> Collection { get; }
}