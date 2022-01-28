namespace mongodb.repository.Contracts;

public interface IMongoDbCredentials
{
    string Username { get; set; }
    string Password { get; set; }
}