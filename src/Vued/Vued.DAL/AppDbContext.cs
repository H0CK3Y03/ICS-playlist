using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;
using Vued.DAL.Seeds;

namespace Vued.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            MediaFileSeed.Seed(modelBuilder);
            WatchlistSeed.Seed(modelBuilder);
            WatchlistMediaSeed.Seed(modelBuilder);
        }
    }
}