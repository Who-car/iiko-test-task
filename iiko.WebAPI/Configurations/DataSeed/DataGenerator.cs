using Bogus;
using WebAPI.Entities;

namespace WebAPI.Configurations.DataSeed;

public class DataGenerator
{
    public const int NumberOfClients = 20;
    public static List<Client> Clients = new List<Client>();
    
    public static void InitData()
    {
        GenerateClients();
    }
    
    private static void GenerateClients()
    {
        var id = 1;
        Clients = new Faker<Client>()
            .RuleFor(client => client.Id, _ => id++)
            .RuleFor(client => client.Username, f => f.Internet.UserName())
            .RuleFor(client => client.SystemId, f => f.Random.Guid())
            .Generate(NumberOfClients);
    }
}