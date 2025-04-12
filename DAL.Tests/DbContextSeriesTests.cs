using DAL.Entities;
using DAL;
using DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace DAL.Tests;

/// <summary>
/// Unit tests for the Series entity.
/// </summary>
public class DbContextSeriesTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task GetAll_Series_ContainsSeededSeries()
    {
        var series = await AppDbContextSUT.Series.ToListAsync();

        Assert.NotEmpty(series);
    }

    [Fact]
    public async Task GetById_Series_Retrieved()
    {
        var expectedSeries = await AppDbContextSUT.Series.FirstAsync();

        var entity = await AppDbContextSUT.Series.SingleOrDefaultAsync(s => s.Id == expectedSeries.Id);

        Assert.NotNull(entity);
        Assert.Equal(expectedSeries.Name, entity.Name);
    }

    [Fact]
    public async Task AddNew_Series_Persisted()
    {
        var entity = new Series
        {
            Name = "Stranger Things",
            Status = MediaStatus.PlanToWatch,
            ReleaseDate = 2016,
        };

        AppDbContextSUT.Series.Add(entity);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Series
            .FirstOrDefaultAsync(s => s.Name == entity.Name && s.ReleaseDate == entity.ReleaseDate);

        Assert.NotNull(actualEntity);
        Assert.Equal(entity.Name, actualEntity.Name);
        Assert.Equal(entity.ReleaseDate, actualEntity.ReleaseDate);
    }

    [Fact]
    public async Task Update_Series_Persisted()
    {
        var series = await AppDbContextSUT.Series.FirstAsync();
        var updatedName = series.Name + " Updated";

        series.Name = updatedName;

        AppDbContextSUT.Series.Update(series);
        await AppDbContextSUT.SaveChangesAsync();

        var actualEntity = await AppDbContextSUT.Series.SingleAsync(s => s.Id == series.Id);

        Assert.Equal(updatedName, actualEntity.Name);
    }

    [Fact]
    public async Task Delete_Series_Deleted()
    {
        var series = await AppDbContextSUT.Series.FirstAsync();
        var countBefore = await AppDbContextSUT.Series.CountAsync();

        AppDbContextSUT.Series.Remove(series);
        await AppDbContextSUT.SaveChangesAsync();

        var countAfter = await AppDbContextSUT.Series.CountAsync();

        Assert.False(await AppDbContextSUT.Series.AnyAsync(s => s.Id == series.Id));
        Assert.Equal(countBefore - 1, countAfter);
    }
}
