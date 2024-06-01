using AutoMapper;
using Moq;
using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Services;
using WebAPI.Entities;
using WebAPI.Services;

namespace iiko.UnitTests.ClientServiceTests;

public class CreateOnlyUniqueClients
{
    private readonly Mock<IClientRepository> _mockRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly IClientService _clientService;

    public CreateOnlyUniqueClients()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IClientRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _clientService = new ClientService(_mockRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
    }
    
    [Fact]
    public async Task CreateOnlyUniqueClientsAsync_AllClientsUnique_AddsAllClients()
    {
        // Arrange
        var clients = new List<Client>
        {
            new Client { Id = 1L },
            new Client { Id = 2L }
        };

        _mockRepository
            .Setup(repo => 
                repo.CheckIfExistsAsync(It.IsAny<long>()))
            .ReturnsAsync(false);

        // Act
        var result = await _clientService.CreateOnlyUniqueClientsAsync(clients);

        // Assert
        Assert.Empty(result);
        _mockRepository
            .Verify(repo => 
                repo.AddRangeAsync(clients, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork
            .Verify(uow => 
                uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateOnlyUniqueClientsAsync_AllClientsExist_ReturnsAllClients()
    {
        // Arrange
        var clients = new List<Client>
        {
            new Client { Id = 1L },
            new Client { Id = 2L }
        };

        _mockRepository
            .Setup(repo => 
                repo.CheckIfExistsAsync(It.IsAny<long>()))
            .ReturnsAsync(true);

        // Act
        var result = await _clientService.CreateOnlyUniqueClientsAsync(clients);

        // Assert
        Assert.Equal(clients.Count, result.Count);
        _mockRepository
            .Verify(repo => 
                repo.AddRangeAsync(It.IsAny<List<Client>>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork
            .Verify(uow => 
                uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateOnlyUniqueClientsAsync_SomeClientsExist_AddsOnlyUniqueClients()
    {
        // Arrange
        var existingClientId = 1L;
        var newClientId = 2L;
        var clients = new List<Client>
        {
            new Client { Id = existingClientId },
            new Client { Id = newClientId }
        };

        _mockRepository
            .Setup(repo => 
                repo.CheckIfExistsAsync(existingClientId)).ReturnsAsync(true);
        _mockRepository
            .Setup(repo => 
                repo.CheckIfExistsAsync(newClientId)).ReturnsAsync(false);

        // Act
        var result = await _clientService.CreateOnlyUniqueClientsAsync(clients);

        // Assert
        Assert.Single(result);
        Assert.Equal(existingClientId, result.First().Id);
        _mockRepository
            .Verify(repo => 
                repo.AddRangeAsync(
                    It.Is<List<Client>>(list => list.Count == 1 && list[0].Id == newClientId), 
                    It.IsAny<CancellationToken>()), 
                Times.Once);
        _mockUnitOfWork
            .Verify(uow => 
                uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}