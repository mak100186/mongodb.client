namespace mongodb.repository.Services;

using Contracts;
using MongoDB.Driver;

public class CollectionService<T> : ICollectionService<T>
    where T : ICollectionItem
{
    public CollectionService(IMongoCollection<T> collection)
    {
        Collection = collection;
    }

    public IMongoCollection<T> Collection { get; }

    public async Task<List<T>> GetAsync()
    {
        return await Collection.Find(_ => true).ToListAsync();
    }

    public async Task<T?> GetAsync(string id)
    {
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T newBook)
    {
        await Collection.InsertOneAsync(newBook);
    }

    public async Task UpdateAsync(string id, T updatedBook)
    {
        await Collection.ReplaceOneAsync(x => x.Id == id, updatedBook);
    }

    public async Task RemoveAsync(string id)
    {
        await Collection.DeleteOneAsync(x => x.Id == id);
    }
}