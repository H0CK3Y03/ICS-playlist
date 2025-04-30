using Vued.DAL.Entities;
using Vued.DAL;
using Vued.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Vued.DAL.Tests;

public class DbContextMovieTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task GetAll_Movies_ContainsSeededMovies()
    {
        var movies = await AppDbContextSUT.Movies.ToListAsync();

        Assert.NotEmpty(movies);
    }

    [Fact]
    public async Task GetById_Movie_Retrieved()
    {
        var expectedMovie = await AppDbContextSUT.Movies.FirstAsync();

        var entity = await AppDbContextSUT.Movies.SingleOrDefaultAsync(m => m.Id == expectedMovie.Id);

        Assert.NotNull(entity);
        Assert.Equal(expectedMovie.Name, entity.Name);
    }

    [Fact]
    public async Task AddNew_Movie_Persisted()
    {
        var entity = new Movie
        {
            Name = "Interstellar",
            Status = MediaStatus.PlanToWatch,
            Director = "Christopher Nolan",
            ReleaseDate = 2014,
            Length = 169,
        };

        AppDbContextSUT.Movies.Add(entity);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Movies
            .SingleOrDefaultAsync(m => m.Name == entity.Name && m.ReleaseDate == entity.ReleaseDate);

        Assert.NotNull(actualEntity);
        Assert.Equal(entity.Name, actualEntity.Name);
    }

    [Fact]
    public async Task Update_Movie_Persisted()
    {
        var movie = await AppDbContextSUT.Movies.FirstAsync();
        var updatedName = movie.Name + " Updated";
        var originalLength = movie.Length;
        var originalFavourite = movie.Favourite;

        movie.Name = updatedName;
        movie.Favourite = !originalFavourite;

        AppDbContextSUT.Movies.Update(movie);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Movies.SingleAsync(m => m.Id == movie.Id);

        Assert.Equal(updatedName, actualEntity.Name);
        Assert.Equal(originalLength, actualEntity.Length);
        Assert.NotEqual(originalFavourite, actualEntity.Favourite);
    }

    [Fact]
    public async Task Delete_Movie_Deleted()
    {
        var movie = await AppDbContextSUT.Movies.FirstAsync();
        var countBefore = await AppDbContextSUT.Movies.CountAsync();

        AppDbContextSUT.Movies.Remove(movie);
        await AppDbContextSUT.SaveChangesAsync();

        var countAfter = await AppDbContextSUT.Movies.CountAsync();

        Assert.False(await AppDbContextSUT.Movies.AnyAsync(m => m.Id == movie.Id));
        Assert.Equal(countBefore - 1, countAfter);
    }
}
