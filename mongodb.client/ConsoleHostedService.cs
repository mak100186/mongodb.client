namespace mongodb.client;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using repository.Configs;
using repository.Contracts;
using repository.Extensions;
using repository.Models;
using repository.Repository;

public class ConsoleHostedService : IHostedService
{
    private int? _exitCode;
    private readonly ILogger _logger;
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly IConfiguration _configuration;
    private readonly IMongoDbCredentials _credentials;
    public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime, IConfiguration configuration, IMongoDbCredentials credentials)
    {
        _logger = logger;
        _appLifetime = appLifetime;
        _configuration = configuration;
        _credentials = credentials;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

        _appLifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
                {
                    try
                    {
                        _logger.LogInformation("Running Demo!");

                        await RunDemoAsync();
                        
                        _exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                        _exitCode = 1;
                    }
                    finally
                    {
                        // Stop the application once the work is done
                        _appLifetime.StopApplication();
                    }
                },
                cancellationToken);
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Exiting with return code: {_exitCode}");

        // Exit code may be null if the user cancelled via Ctrl+C/SIGTERM
        Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
        return Task.CompletedTask;
    }

    private async Task RunDemoAsync()
    {
        var dbConfig = new DatabaseConfigs
        {
            ConnectionString = _configuration.GetSection("Database")["ConnectionString"],
            DatabaseName = _configuration.GetSection("Database")["DatabaseName"],
            CollectionName = _configuration.GetSection("Database")["CollectionName"]
        };

        var mongoClient = new MongoClient(_credentials.Apply(dbConfig.ConnectionString));
        var database = mongoClient.GetDatabase(dbConfig.DatabaseName);

        var repository = new Repository<Zip>(dbConfig, database);
        var zip = await repository.CollectionService.GetAsync("5c8eccc1caa187d17ca6ed16");

        Console.WriteLine($"{zip.ToJsonString()}");
    }
}