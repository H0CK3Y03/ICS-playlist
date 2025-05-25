using System;
using System.Collections.Generic;

namespace Vued.DAL.Entities;

public class WatchlistEntity : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<WatchlistMediaFileEntity> WatchlistMediaFiles { get; set; } = null!;

    public int MediaCount => WatchlistMediaFiles?.Count ?? 0;
}
