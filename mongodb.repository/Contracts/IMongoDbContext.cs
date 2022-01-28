namespace mongodb.repository.Contracts;

using Models;
using MongoDB.Driver;

public interface IMongoDbContext
{
    ICollectionService<Zip> ZipCollectionService { get; }
    IMongoCollection<Zip> ZipCollection { get; }
}