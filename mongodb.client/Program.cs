// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mongodb.client;
using mongodb.repository.Configs;
using mongodb.repository.Contracts;

Console.WriteLine("Please enter the mongodb username:");
var username = Console.ReadLine();

Console.WriteLine("Please enter the mongodb password:");
var password = Console.ReadLine();

var credentials = new MongoDbCredentials
{
    Username = username,
    Password = password
};

await Host.CreateDefaultBuilder(args)
    .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .ConfigureHostConfiguration(configurationBuilder => { configurationBuilder.AddJsonFile("appsettings.json", false, false); })
    .ConfigureServices((_, services) =>
    {
        services.AddHostedService<ConsoleHostedService>();
        services.AddSingleton<IMongoDbCredentials>(credentials);
    })
    .RunConsoleAsync();