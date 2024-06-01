namespace WebAPI.Abstractions.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public void Rollback();
}