namespace mongodb.repository.Repository;

using Contracts;
using Extensions;
using Models;
using MongoDB.Driver;
using Services;

public class MongoDbContext : IMongoDbContext
{
    public MongoDbContext(IDatabaseConfigs dbConfigs, IMongoDbCredentials credentials)
    {
        //not a testable approach
        var mongoClient = new MongoClient(credentials.Apply(dbConfigs.ConnectionString));
        var database = mongoClient.GetDatabase(dbConfigs.DatabaseName);
        ZipCollection = database.GetCollection<Zip>(dbConfigs.CollectionName);
        ZipCollectionService = new CollectionService<Zip>(ZipCollection);
    }

    public ICollectionService<Zip> ZipCollectionService { get; }
    public IMongoCollection<Zip> ZipCollection { get; }
}

