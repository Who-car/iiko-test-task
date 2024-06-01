using Microsoft.EntityFrameworkCore;
using WebAPI.Configurations.DataSeed;
using WebAPI.Entities;

namespace WebAPI.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DataGenerator.InitData();
        modelBuilder.Entity<Client>().HasData(DataGenerator.Clients);
        
        base.OnModelCreating(modelBuilder);
    }
}