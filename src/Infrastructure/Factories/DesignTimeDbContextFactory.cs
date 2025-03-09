using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Factories;

/// <summary>
///     EF Core CLI migration generation uses this DbContext to create model and migration
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new("app.db");

    public AppDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}