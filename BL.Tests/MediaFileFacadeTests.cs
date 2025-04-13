using Xunit;
using Xunit.Abstractions;
using BL.Facades;
using BL.Mappers;
using BL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace BL.Tests;

public class MediaFileFacadeTests : FacadeTestsBase
{
    private readonly MediaFileModelMapper _mapper;

    public MediaFileFacadeTests(ITestOutputHelper output) : base(output)
    {
        _mapper = new MediaFileModelMapper();
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllMediaFiles()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);

        // Act
        var mediaFiles = await facade.GetAllAsync();

        // Assert
        Assert.NotNull(mediaFiles);
        Assert.Equal(4, mediaFiles.Count);
        Assert.Contains(mediaFiles, m => m.Name == "Inception" && m.ReleaseDate == 2010);
        Assert.Contains(mediaFiles, m => m.Name == "The Matrix" && m.ReleaseDate == 1999);
        Assert.Contains(mediaFiles, m => m.Name == "Breaking Bad" && m.ReleaseDate == 2008);
        Assert.Contains(mediaFiles, m => m.Name == "Stranger Things" && m.ReleaseDate == 2016);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingMovie_ReturnsMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);

        // Act
        var mediaFile = await facade.GetByIdAsync(1); // Inception

        // Assert
        Assert.NotNull(mediaFile);
        Assert.Equal("Inception", mediaFile.Name);
        Assert.Equal(2010, mediaFile.ReleaseDate);
        Assert.Equal(148, mediaFile.Duration);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingSeries_ReturnsSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);

        // Act
        var mediaFile = await facade.GetByIdAsync(3); // Breaking Bad

        // Assert
        Assert.NotNull(mediaFile);
        Assert.Equal("Breaking Bad", mediaFile.Name);
        Assert.Equal(2008, mediaFile.ReleaseDate);
        Assert.Equal(60, mediaFile.Duration); // Assumed episode duration
    }

    [Fact]
    public async Task SaveAsync_NewMovie_AddsMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);
        var newMediaFile = new MediaFileDetailModel
        {
            Id = 0, // New movie
            Name = "Test Movie",
            Description = "A test movie",
            Director = "Test Director",
            Duration = 120,
            Status = MediaStatus.PlanToWatch,
            ReleaseDate = 2023,
            Rating = "PG",
            URL = "http://example.com",
            Favourite = false
        };

        // Act
        var savedMediaFile = await facade.SaveAsync(newMediaFile);

        // Assert
        Assert.NotNull(savedMediaFile);
        Assert.Equal("Test Movie", savedMediaFile.Name);
        Assert.Equal(120, savedMediaFile.Duration);
        var dbMovie = await dbx.Movies.FirstOrDefaultAsync(m => m.Name == "Test Movie");
        Assert.NotNull(dbMovie);
        Assert.Equal("Test Movie", dbMovie.Name);
        Assert.Equal(120, dbMovie.Length);
    }

    [Fact]
    public async Task SaveAsync_NewSeries_AddsSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);
        var newMediaFile = new MediaFileDetailModel
        {
            Id = 0, // New series
            Name = "Test Series",
            Description = "A test series",
            Director = "Test Director",
            Duration = 30,
            Status = MediaStatus.PlanToWatch,
            ReleaseDate = 2023,
            Rating = "TV-PG",
            URL = "http://example.com",
            Favourite = false
        };

        // Act
        var savedMediaFile = await facade.SaveAsync(newMediaFile);

        // Assert
        Assert.NotNull(savedMediaFile);
        Assert.Equal("Test Series", savedMediaFile.Name);
        Assert.Equal(30, savedMediaFile.Duration);
        var dbSeries = await dbx.Series.FirstOrDefaultAsync(s => s.Name == "Test Series");
        Assert.NotNull(dbSeries);
        Assert.Equal("Test Series", dbSeries.Name);
        Assert.Equal(30, dbSeries.Duration);
        // Verify series-specific field in database
        Assert.Equal(0, dbSeries.NumberOfEpisodes); // Default if not set
    }

    [Fact]
    public async Task DeleteAsync_ExistingMovie_RemovesMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);
        var movieBefore = await dbx.Movies.FirstOrDefaultAsync(m => m.Id == 1);
        Assert.NotNull(movieBefore); // Verify Inception exists

        // Act
        await facade.DeleteAsync(1); // Delete Inception

        // Assert
        var movieAfter = await dbx.Movies.FirstOrDefaultAsync(m => m.Id == 1);
        Assert.Null(movieAfter); // Movie should be gone
    }

    [Fact]
    public async Task DeleteAsync_ExistingSeries_RemovesSeries()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MediaFileFacade(dbx, _mapper);
        var seriesBefore = await dbx.Series.FirstOrDefaultAsync(s => s.Id == 3);
        Assert.NotNull(seriesBefore); // Verify Breaking Bad exists

        // Act
        await facade.DeleteAsync(3); // Delete Breaking Bad

        // Assert
        var seriesAfter = await dbx.Series.FirstOrDefaultAsync(s => s.Id == 3);
        Assert.Null(seriesAfter); // Series should be gone
    }
}
