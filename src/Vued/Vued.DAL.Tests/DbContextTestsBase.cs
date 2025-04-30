using Vued.DAL;
using Vued.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Vued.DAL.Tests;

public class DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        DbContextFactory = new DbContextSqLiteFactory(GetType().FullName!);
        AppDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<AppDbContext> DbContextFactory { get; }
    protected AppDbContext AppDbContextSUT { get; }

    public async Task InitializeAsync()
    {
        await AppDbContextSUT.Database.EnsureDeletedAsync();
        await AppDbContextSUT.Database.EnsureCreatedAsync();

        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await AppDbContextSUT.Database.EnsureDeletedAsync();
        await AppDbContextSUT.DisposeAsync();
    }
}
