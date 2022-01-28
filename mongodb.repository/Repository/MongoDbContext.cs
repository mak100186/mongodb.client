namespace mongodb.repository.Repository;

using Contracts;
using Models;
using MongoDB.Driver;
using Services;

public class MongoDbContext : IMongoDbContext
{
    public MongoDbContext(IDatabaseConfigs dbConfigs, IMongoDatabase database)
    {
        //not a testable approach
        ZipCollection = database.GetCollection<Zip>(dbConfigs.CollectionName);
        ZipCollectionService = new CollectionService<Zip>(ZipCollection);
    }

    public ICollectionService<Zip> ZipCollectionService { get; }
    public IMongoCollection<Zip> ZipCollection { get; }
}