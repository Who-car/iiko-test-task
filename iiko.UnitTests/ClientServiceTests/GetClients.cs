using System.Linq.Expressions;
using Moq;
using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Services;
using WebAPI.Entities;
using WebAPI.Services;

namespace iiko.UnitTests.ClientServiceTests;

public class GetClients
{
    private readonly Mock<IClientRepository> _mockRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IClientService _clientService;

    public GetClients()
    {
        _mockRepository = new Mock<IClientRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _clientService = new ClientService(_mockRepository.Object, _mockUnitOfWork.Object);
    }
    
    [Fact]
    public async Task GetClientsAsync_NoSystemId_ReturnsAllClients()
    {
        // Arrange
        var clients = new List<Client>
        {
            new Client { Id = 1L, SystemId = Guid.NewGuid() },
            new Client { Id = 2L, SystemId = Guid.NewGuid() }
        };

        _mockRepository
            .Setup(repo => 
                repo.GetAsync(
                    It.IsAny<int>(), 
                    It.IsAny<List<Expression<Func<Client, bool>>>>(), 
                    It.IsAny<Func<IQueryable<Client>, IOrderedQueryable<Client>>>(),
                    new CancellationToken()))
            .ReturnsAsync(clients);

        // Act
        var result = await _clientService.GetClientsAsync(null);

        // Assert
        Assert.Equal(clients.Count, result.Count);
    }

    [Fact]
    public async Task GetClientsAsync_WithSystemId_ReturnsFilteredClients()
    {
        // Arrange
        var systemId = Guid.NewGuid();
        var clients = new List<Client>
        {
            new Client { Id = 1L, SystemId = systemId },
            new Client { Id = 2L, SystemId = systemId }
        };

        _mockRepository
            .Setup(repo => repo.GetAsync(
                It.IsAny<int>(), 
                It.Is<List<Expression<Func<Client, bool>>>>(filters => 
                    filters.Count == 1 && filters[0].Compile()(clients[0])),
                It.IsAny<Func<IQueryable<Client>, IOrderedQueryable<Client>>>(),
                new CancellationToken()))
            .ReturnsAsync(clients);

        // Act
        var result = await _clientService.GetClientsAsync(systemId);

        // Assert
        Assert.Equal(clients.Count, result.Count);
    }
}