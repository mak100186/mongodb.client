namespace mongodb.repository.Contracts;

using MongoDB.Driver;

public interface ICollectionService<T> where T : ICollectionItem
{
    IMongoCollection<T> Collection { get; }

    Task<List<T>> GetAsync();
    Task<T?> GetAsync(string id);
    Task CreateAsync(T newBook);
    Task UpdateAsync(string id, T updatedBook);
    Task RemoveAsync(string id);
}