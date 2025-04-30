using Vued.DAL.Entities;
using Vued.DAL;
using Vued.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Vued.DAL.Tests;

public class DbContextWatchlistTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task GetAll_Watchlists_ContainsSeededWatchlist()
    {
        var watchlists = await AppDbContextSUT.Watchlists.ToListAsync();

        Assert.NotEmpty(watchlists);
    }

    [Fact]
    public async Task GetById_Watchlist_Retrieved()
    {
        var expectedWatchlist = await AppDbContextSUT.Watchlists.FirstAsync();

        var entity = await AppDbContextSUT.Watchlists.SingleOrDefaultAsync(w => w.Id == expectedWatchlist.Id);

        Assert.NotNull(entity);
        Assert.Equal(expectedWatchlist.Name, entity.Name);
    }

    [Fact]
    public async Task AddNew_Watchlist_Persisted()
    {
        var entity = new Watchlist
        {
            Name = "Weekend Movies",
        };

        AppDbContextSUT.Watchlists.Add(entity);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Watchlists
            .FirstOrDefaultAsync(w => w.Name == entity.Name);

        Assert.NotNull(actualEntity);
        Assert.Equal(entity.Name, actualEntity.Name);
    }

    [Fact]
    public async Task Update_Watchlist_Persisted()
    {
        var watchlist = await AppDbContextSUT.Watchlists.FirstAsync();
        var updatedName = watchlist.Name + " Updated";

        watchlist.Name = updatedName;

        AppDbContextSUT.Watchlists.Update(watchlist);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Watchlists.SingleAsync(w => w.Id == watchlist.Id);

        Assert.Equal(updatedName, actualEntity.Name);
    }

    [Fact]
    public async Task Delete_Watchlist_Deleted()
    {
        var watchlist = await AppDbContextSUT.Watchlists.FirstAsync();
        var countBefore = await AppDbContextSUT.Watchlists.CountAsync();

        AppDbContextSUT.Watchlists.Remove(watchlist);
        await AppDbContextSUT.SaveChangesAsync();

        var countAfter = await AppDbContextSUT.Watchlists.CountAsync();

        Assert.False(await AppDbContextSUT.Watchlists.AnyAsync(w => w.Id == watchlist.Id));
        Assert.Equal(countBefore - 1, countAfter);
    }
}
