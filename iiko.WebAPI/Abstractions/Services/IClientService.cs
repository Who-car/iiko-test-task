using WebAPI.Entities;

namespace WebAPI.Abstractions.Services;

public interface IClientService
{
    public Task<Client?> GetClientAsync(long clientId);
    public Task<List<Client>> GetClientsAsync(Guid? systemId, int amount = 0);
    public Task<Client> CreateClientAsync(Client client);
    public Task<List<Client>> CreateOnlyUniqueClientsAsync(List<Client> clients);
    public Task<Client> DeleteClientAsync(long clientId);
    public Task<Client> UpdateClientAsync(Client client);
}