using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;
using Vued.DAL.Seeds;

namespace Vued.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- Inheritance (TPH) -----
            modelBuilder.Entity<Movie>().HasBaseType<MediaFile>();
            modelBuilder.Entity<Series>().HasBaseType<MediaFile>();

            // ----- Many-to-Many: MediaFile <-> Genre -----
            modelBuilder.Entity<MediaFile>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.MediaFiles);

            // ----- Many-to-Many: MediaFile <-> Watchlist -----
            modelBuilder.Entity<MediaFile>()
                .HasMany(m => m.Watchlists)
                .WithMany(w => w.MediaFiles);

            // ----- Seed Data -----
            GenreMediaSeed.Seed(modelBuilder);
            GenreSeed.Seed(modelBuilder);
            MovieSeed.Seed(modelBuilder);
            SeriesSeed.Seed(modelBuilder);
            WatchlistSeed.Seed(modelBuilder);
            WatchlistMediaSeed.Seed(modelBuilder);

        }
    }
}
