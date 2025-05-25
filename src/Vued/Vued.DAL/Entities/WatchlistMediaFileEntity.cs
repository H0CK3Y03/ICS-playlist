using System;

namespace Vued.DAL.Entities;

public class WatchlistMediaFileEntity : IEntity
{
    public required Guid Id { get; set; }

    public Guid WatchlistId { get; set; }
    public WatchlistEntity Watchlist { get; set; } = null!;

    public Guid MediaFileId { get; set; }
    public MediaFileEntity MediaFile { get; set; } = null!;
}
