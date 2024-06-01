using WebAPI.Abstractions.Repositories;

namespace WebAPI.DataAccess.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await appDbContext.SaveChangesAsync(cancellationToken);
    }

    public void Rollback()
    {
        appDbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }
}