using Xunit;
using Xunit.Abstractions;
using Vued.BL.Facades;
using Vued.BL.Models;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.BL.Tests;

public class MovieFacadeTests : FacadeTestsBase
{
    public MovieFacadeTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task GetByIdAsync_ExistingMovie_ReturnsMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MovieFacade(dbx);

        // Act
        var movie = await facade.GetByIdAsync(1); // Inception from MovieSeed

        // Assert
        Assert.NotNull(movie);
        Assert.Equal("Inception", movie.Name);
        Assert.Equal(148, movie.Length);
        Assert.Equal(MediaStatus.Completed, movie.Status);
        Assert.Equal(2010, movie.ReleaseDate);
        Assert.Equal("PG-13", movie.Rating);
    }

    [Fact]
    public async Task SaveAsync_NewMovie_AddsMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MovieFacade(dbx);
        var newMovie = new MovieModel
        {
            Id = 0,
            Name = "Test Movie",
            Length = 120,
            Duration = 120,
            Status = MediaStatus.PlanToWatch,
            ReleaseDate = 2023,
            Rating = "PG",
            Description = "A test movie",
            Director = "Test Director",
            Favourite = false
        };

        // Act
        var savedMovie = await facade.SaveAsync(newMovie);

        // Assert
        Assert.NotNull(savedMovie);
        Assert.Equal("Test Movie", savedMovie.Name);
        var dbMovie = await dbx.Movies.FirstOrDefaultAsync(m => m.Name == "Test Movie");
        Assert.NotNull(dbMovie);
        Assert.Equal(120, dbMovie.Length);
        Assert.Equal(MediaStatus.PlanToWatch, dbMovie.Status);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllMovies()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MovieFacade(dbx);

        // Act
        var movies = await facade.GetAllAsync();

        // Assert
        Assert.NotNull(movies);
        Assert.Equal(2, movies.Count); // Inception, The Matrix from MovieSeed
        Assert.Contains(movies, m => m.Name == "Inception");
        Assert.Contains(movies, m => m.Name == "The Matrix");
    }

    [Fact]
    public async Task DeleteAsync_ExistingMovie_RemovesMovie()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new MovieFacade(dbx);

        // Act
        await facade.DeleteAsync(1); // Delete Inception

        // Assert
        var movie = await dbx.Movies.FirstOrDefaultAsync(m => m.Id == 1);
        Assert.Null(movie); // Movie should be gone
    }
}
