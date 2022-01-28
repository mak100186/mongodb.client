namespace mongodb.repository.Configs;

using Contracts;

public class DatabaseConfigs : IDatabaseConfigs
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}