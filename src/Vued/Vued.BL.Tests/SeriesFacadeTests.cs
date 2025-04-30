using Xunit;
using Xunit.Abstractions;
using Vued.BL.Facades;
using Vued.BL.Mappers;
using Vued.BL.Models;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.BL.Tests;

public class SeriesFacadeTests : FacadeTestsBase
{
    private readonly SeriesMapper _mapper;

    public SeriesFacadeTests(ITestOutputHelper output) : base(output)
    {
        _mapper = new SeriesMapper();
    }

    [Fact]
    public async Task GetAllAsync_ReturnsSeededSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new SeriesFacade(dbx, _mapper);

        // Act
        var series = await facade.GetAllAsync();

        // Assert
        Assert.NotNull(series);
        Assert.Equal(2, series.Count);
        Assert.Contains(series, s => s.Name == "Breaking Bad" && s.NumberOfEpisodes == 62 && s.ReleaseDate == 2008);
        Assert.Contains(series, s => s.Name == "Stranger Things" && s.NumberOfEpisodes == 34 && s.ReleaseDate == 2016);
    }

    [Fact]
    public async Task SaveAsync_NewSeries_AddsSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new SeriesFacade(dbx, _mapper);
        var newSeries = new SeriesDetailModel
        {
            Id = 0, // New series
            Name = "Test Series",
            Description = "A test series",
            Director = "Test Director",
            Duration = 30, // Episode duration in minutes
            Status = MediaStatus.PlanToWatch,
            ReleaseDate = 2023,
            Rating = "TV-PG",
            URL = "http://example.com",
            Favourite = false,
            NumberOfEpisodes = 10
        };

        // Act
        var savedSeries = await facade.SaveAsync(newSeries);

        // Assert
        Assert.NotNull(savedSeries);
        Assert.Equal("Test Series", savedSeries.Name);
        Assert.Equal("A test series", savedSeries.Description);
        Assert.Equal(30, savedSeries.Duration);
        Assert.Equal(10, savedSeries.NumberOfEpisodes);
        var dbSeries = await dbx.Series.FirstOrDefaultAsync(s => s.Name == "Test Series");
        Assert.NotNull(dbSeries);
        Assert.Equal("Test Series", dbSeries.Name);
        Assert.Equal(30, dbSeries.Duration);
        Assert.Equal(10, dbSeries.NumberOfEpisodes);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingSeries_ReturnsSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new SeriesFacade(dbx, _mapper);

        // Act
        var series = await facade.GetByIdAsync(3); // Breaking Bad from seed

        // Assert
        Assert.NotNull(series);
        Assert.Equal("Breaking Bad", series.Name);
        Assert.Equal(62, series.NumberOfEpisodes);
        Assert.Equal(2008, series.ReleaseDate);
    }

    [Fact]
    public async Task DeleteAsync_ExistingSeries_RemovesSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new SeriesFacade(dbx, _mapper);
        var seriesBefore = await dbx.Series.FirstOrDefaultAsync(s => s.Id == 3);
        Assert.NotNull(seriesBefore); // Verify Breaking Bad exists

        // Act
        await facade.DeleteAsync(3); // Delete Breaking Bad

        // Assert
        var seriesAfter = await dbx.Series.FirstOrDefaultAsync(s => s.Id == 3);
        Assert.Null(seriesAfter); // Series should be gone
    }

}
