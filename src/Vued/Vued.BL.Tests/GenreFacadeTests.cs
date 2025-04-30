using Xunit;
using Xunit.Abstractions;
using Vued.BL.Facades;
using Vued.BL.Mappers;
using Vued.BL.Models;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.BL.Tests;

public class GenreFacadeTests : FacadeTestsBase
{
    private readonly GenreModelMapper _mapper;

    public GenreFacadeTests(ITestOutputHelper output) : base(output)
    {
        _mapper = new GenreModelMapper();
    }

    [Fact]
    public async Task GetAsync_ExistingGenre_ReturnsGenre()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new GenreFacade(dbx, _mapper);

        // Act
        var genre = await facade.GetAsync(1); // Action from GenreSeed

        // Assert
        Assert.NotNull(genre);
        Assert.Equal("Action", genre.Name);
    }

    [Fact]
    public async Task SaveAsync_NewGenre_AddsGenre()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new GenreFacade(dbx, _mapper);
        var newGenre = new GenreDetailModel
        {
            Id = 0, // New genre
            Name = "Sci-Fi"
        };

        // Act
        var savedGenre = await facade.SaveAsync(newGenre);

        // Assert
        Assert.NotNull(savedGenre);
        Assert.Equal("Sci-Fi", savedGenre.Name);
        var dbGenre = await dbx.Genres.FirstOrDefaultAsync(g => g.Name == "Sci-Fi");
        Assert.NotNull(dbGenre);
        Assert.Equal("Sci-Fi", dbGenre.Name);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllGenres()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new GenreFacade(dbx, _mapper);

        // Act
        var genres = await facade.GetAllAsync();

        // Assert
        Assert.NotNull(genres);
        Assert.Equal(3, genres.Count()); // Action, Comedy, Drama from GenreSeed
        Assert.Contains(genres, g => g.Name == "Action");
        Assert.Contains(genres, g => g.Name == "Comedy");
        Assert.Contains(genres, g => g.Name == "Drama");
    }

    [Fact]
    public async Task DeleteAsync_ExistingGenre_RemovesGenre()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var facade = new GenreFacade(dbx, _mapper);
        var genreBefore = await dbx.Genres.FirstOrDefaultAsync(g => g.Id == 1);
        Assert.NotNull(genreBefore); // Verify Action exists

        // Act
        await facade.DeleteAsync(1); // Delete Action

        // Assert
        var genreAfter = await dbx.Genres.FirstOrDefaultAsync(g => g.Id == 1);
        Assert.Null(genreAfter); // Genre should be gone
    }
}
