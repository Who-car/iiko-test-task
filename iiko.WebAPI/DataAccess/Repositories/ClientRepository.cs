using WebAPI.Abstractions.Repositories;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Repositories;

public class ClientRepository(AppDbContext appDbContext) : 
    BaseRepository<Client>(appDbContext), IClientRepository
{
}