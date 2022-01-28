namespace mongodb.repository.Configs;

using Contracts;

public class MongoDbCredentials : IMongoDbCredentials
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}