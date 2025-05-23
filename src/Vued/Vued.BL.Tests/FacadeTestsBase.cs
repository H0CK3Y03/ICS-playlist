using System.Text;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Vued.DAL;
using Vued.BL.Mappers;
using Vued.DAL.Factories;

namespace Vued.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteFactory(GetType().FullName!);

        GenreModelMapper = new GenreModelMapper();
        MovieMapper = new MovieModelMapper();
        SeriesMapper = new SeriesModelMapper();
        WatchlistMapper = new WatchlistModelMapper();
        MediaFileModelMapper = new MediaFileModelMapper();
    }

    protected IDbContextFactory<AppDbContext> DbContextFactory { get; }

    protected GenreModelMapper GenreModelMapper { get; }
    protected MovieModelMapper MovieMapper { get; }
    protected SeriesModelMapper SeriesMapper { get; }
    protected WatchlistModelMapper WatchlistMapper { get; }
    protected MediaFileModelMapper MediaFileModelMapper { get; }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}

public class XUnitTestOutputConverter : TextWriter
{
    private readonly ITestOutputHelper _output;
    public XUnitTestOutputConverter(ITestOutputHelper output) => _output = output;
    public override Encoding Encoding => Encoding.UTF8;
    public override void WriteLine(string? message) => _output.WriteLine(message);
    public override void WriteLine(string? format, params object?[] args) => _output.WriteLine(format, args);
}
