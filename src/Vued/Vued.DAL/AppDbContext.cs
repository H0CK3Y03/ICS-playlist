using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;
using Vued.DAL.Seeds;

namespace Vued.DAL;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<SeriesEntity> Series { get; set; }
    public DbSet<WatchlistEntity> Watchlists { get; set; }

    public DbSet<WatchlistMediaFileEntity> WatchlistMediaFileEntities { get; set; }
    public DbSet<MediaFileGenreEntity> MediaFileGenreEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MovieEntity>().HasBaseType<MediaFileEntity>();
        modelBuilder.Entity<SeriesEntity>().HasBaseType<MediaFileEntity>();

        modelBuilder.Entity<WatchlistMediaFileEntity>()
            .HasOne(wmf => wmf.Watchlist)
            .WithMany(w => w.WatchlistMediaFiles)
            .HasForeignKey(wmf => wmf.WatchlistId);

        modelBuilder.Entity<WatchlistMediaFileEntity>()
            .HasOne(wmf => wmf.MediaFile)
            .WithMany(m => m.WatchlistMediaFiles)
            .HasForeignKey(wmf => wmf.MediaFileId);

        modelBuilder.Entity<WatchlistMediaFileEntity>()
            .HasIndex(x => new { x.WatchlistId, x.MediaFileId })
            .IsUnique();

        modelBuilder.Entity<MediaFileGenreEntity>()
            .HasOne(mfg => mfg.MediaFile)
            .WithMany(m => m.MediaFileGenres)
            .HasForeignKey(mfg => mfg.MediaFileId);

        modelBuilder.Entity<MediaFileGenreEntity>()
            .HasOne(mfg => mfg.Genre)
            .WithMany(g => g.MediaFileGenres)
            .HasForeignKey(mfg => mfg.GenreId);

        modelBuilder.Entity<MediaFileGenreEntity>()
            .HasIndex(x => new { x.MediaFileId, x.GenreId })
            .IsUnique();

        GenreSeed.Seed(modelBuilder);
        MovieSeed.Seed(modelBuilder);
        SeriesSeed.Seed(modelBuilder);
        WatchlistSeed.Seed(modelBuilder);
        MediaFileGenreSeed.Seed(modelBuilder);
        WatchlistMediaFileSeed.Seed(modelBuilder);
    }
}
