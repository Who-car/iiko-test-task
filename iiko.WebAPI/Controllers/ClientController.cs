using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Abstractions.Services;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService service, IMapper mapper) : ControllerBase
{
    // api/client/{clientId}
    [AllowAnonymous]
    [HttpGet("{clientId:long}")]
    public async Task<IActionResult> GetClient(long clientId)
    {
        var result = await service.GetClientAsync(clientId);
        
        return result is null
            ? NotFound(result)
            : Ok(result);
    }

    // api/client/all
    [AllowAnonymous]
    [HttpGet("all")]
    public async Task<IActionResult> GetClients(
        [FromQuery] Guid? systemId,     
        [FromQuery] int amount
    )
    {
        var result = await service.GetClientsAsync(systemId, amount);
        return Ok(result);
    }

    // api/client
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto dto)
    {
        var client = mapper.Map<Client>(dto);
        var result = await service.CreateClientAsync(client);
        return Ok(result);
    }
    
    // api/client/{clientId}
    [AllowAnonymous]
    [HttpPatch("{clientId:long}")]
    public async Task<IActionResult> UpdateClient(
        [FromRoute] long clientId,
        [FromBody] UpdateClientDto dto
    )
    {
        var client = mapper.Map<Client>(dto);
        client.Id = clientId;
        
        var result = await service.UpdateClientAsync(client);
        return Ok(result);
    }

    // api/book/{bookId}
    [AllowAnonymous]
    [HttpDelete("{bookId:long}")]
    public async Task<IActionResult> DeleteBook([FromRoute] long clientId)
    {
        var result = await service.DeleteClientAsync(clientId);
        return Ok(result);
    }
}