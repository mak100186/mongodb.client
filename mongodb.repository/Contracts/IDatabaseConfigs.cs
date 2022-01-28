namespace mongodb.repository.Contracts;

public interface IDatabaseConfigs
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string CollectionName { get; set; }
}