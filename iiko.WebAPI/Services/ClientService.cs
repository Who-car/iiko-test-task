using System.Linq.Expressions;
using AutoMapper;
using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Services;
using WebAPI.Entities;

namespace WebAPI.Services;

public class ClientService(
    IClientRepository repository, 
    IUnitOfWork unitOfWork,
    IMapper mapper) : IClientService
{
    public async Task<Client?> GetClientAsync(long clientId)
    {
        return await repository.GetByIdAsync(clientId);
    }

    public async Task<List<Client>> GetClientsAsync(Guid? systemId, int amount = 0)
    {
        var filters = new List<Expression<Func<Client, bool>>>();
        if (systemId is not null)
            filters.Add(client => client.SystemId == systemId);
        
        var clients = await repository.GetAsync(amount, filters);
        return clients;
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        try
        {
            var result = await repository.AddAsync(client);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public async Task<List<Client>> CreateOnlyUniqueClientsAsync(List<Client> clients)
    {
        var clientsToAdd = new List<Client>();
        var existingClients = new List<Client>();
        
        foreach (var client in clients)
        {
            var clientExists = await repository.CheckIfExistsAsync(client.Id);
            
            if (clientExists)
                existingClients.Add(client);
            else
                clientsToAdd.Add(client);
        }

        if (clientsToAdd.Count > 0)
        {
            await repository.AddRangeAsync(clientsToAdd);
            await unitOfWork.SaveChangesAsync();
        }

        return existingClients;
    }

    public async Task<Client> DeleteClientAsync(long clientId)
    {
        try
        {
            var result = repository.Delete(clientId);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        try
        {
            // var client = await repository.GetByIdAsync(newClient.Id);
            // client = mapper.Map(newClient, client);
            
            var result = repository.Update(client);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}