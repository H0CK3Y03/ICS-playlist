using System;
using System.Collections.Generic;

namespace Vued.BL.Models;

public record WatchlistModel : ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public List<int> MediaFileIds { get; set; } = new();

    public static WatchlistModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Description = string.Empty,
        MediaFileIds = new()
    };
}
