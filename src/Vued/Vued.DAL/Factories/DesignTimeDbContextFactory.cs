using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vued.DAL.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new("app.db");

    public AppDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}
