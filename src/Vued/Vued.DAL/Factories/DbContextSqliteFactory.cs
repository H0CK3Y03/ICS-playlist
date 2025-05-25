using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Factories;

public class DbContextSqLiteFactory : IDbContextFactory<AppDbContext>
{
    private readonly DbContextOptionsBuilder<AppDbContext> _contextOptionsBuilder = new();

    public DbContextSqLiteFactory(string databaseName)
    {
        _contextOptionsBuilder.UseSqlite($"Data Source={databaseName};Cache=Shared");
    }

    public AppDbContext CreateDbContext() => new(_contextOptionsBuilder.Options);
}
