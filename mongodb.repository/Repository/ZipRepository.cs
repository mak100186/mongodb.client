namespace mongodb.repository.Repository;

using Contracts;
using MongoDB.Driver;
using Services;

public class Repository<T> : IRepository<T> where T : ICollectionItem
{
    public Repository(IDatabaseConfigs dbConfigs, IMongoDatabase database)
    {
        //not a testable approach
        Collection = database.GetCollection<T>(dbConfigs.CollectionName);
        CollectionService = new CollectionService<T>(Collection);
    }

    public ICollectionService<T> CollectionService { get; }
    public IMongoCollection<T> Collection { get; }
}