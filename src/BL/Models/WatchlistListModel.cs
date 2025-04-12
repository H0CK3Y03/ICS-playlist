using System;

namespace BL.Models;

public record WatchlistListModel : ModelBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public int MediaCount { get; set; }

    public static WatchlistListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Description = string.Empty,
        MediaCount = default
    };
}
