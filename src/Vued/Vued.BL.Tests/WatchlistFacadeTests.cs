using Xunit;
using Xunit.Abstractions;
using Vued.BL.Facades;
using Vued.BL.Mappers;
using Vued.BL.Models;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.BL.Tests;

public class WatchlistFacadeTests : FacadeTestsBase
{
    private readonly WatchlistMapper _mapper;

    public WatchlistFacadeTests(ITestOutputHelper output) : base(output)
    {
        _mapper = new WatchlistMapper();
    }

    [Fact]
    public async Task GetAllAsync_ReturnsSeededWatchlists()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new WatchlistFacade(dbx, _mapper);

        // Act
        var watchlists = await facade.GetAllAsync();

        // Assert
        Assert.NotNull(watchlists);
        Assert.Equal(2, watchlists.Count);
        Assert.Contains(watchlists, w => w.Name == "My Favorites" && w.Description == "Top-rated movies and series");
        Assert.Contains(watchlists, w => w.Name == "Watch Later" && w.Description == "Movies and series to watch later");
    }

    [Fact]
    public async Task SaveAsync_NewWatchlist_AddsWatchlist()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new WatchlistFacade(dbx, _mapper);
        var newWatchlist = new WatchlistDetailModel
        {
            Id = 0, // New watchlist
            Name = "Test Watchlist", // Unique name
            Description = "Test description"
        };

        // Act
        var savedWatchlist = await facade.SaveAsync(newWatchlist);

        // Assert
        Assert.NotNull(savedWatchlist);
        Assert.Equal("Test Watchlist", savedWatchlist.Name);
        Assert.Equal("Test description", savedWatchlist.Description);
        var dbWatchlist = await dbx.Watchlists.FirstOrDefaultAsync(w => w.Name == "Test Watchlist");
        Assert.NotNull(dbWatchlist);
        Assert.Equal("Test Watchlist", dbWatchlist.Name);
        Assert.Equal("Test description", dbWatchlist.Description);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingWatchlist_ReturnsWatchlist()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new WatchlistFacade(dbx, _mapper);

        // Act
        var watchlist = await facade.GetByIdAsync(1); // My Favorites from seed

        // Assert
        Assert.NotNull(watchlist);
        Assert.Equal("My Favorites", watchlist.Name);
        Assert.Equal("Top-rated movies and series", watchlist.Description);
    }

    [Fact]
    public async Task DeleteAsync_ExistingWatchlist_RemovesWatchlist()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new WatchlistFacade(dbx, _mapper);
        var watchlistBefore = await dbx.Watchlists.FirstOrDefaultAsync(w => w.Id == 1);
        Assert.NotNull(watchlistBefore); // Verify My Favorites exists

        // Act
        await facade.DeleteAsync(1); // Delete My Favorites

        // Assert
        var watchlistAfter = await dbx.Watchlists.FirstOrDefaultAsync(w => w.Id == 1);
        Assert.Null(watchlistAfter); // Watchlist should be gone
    }
}
