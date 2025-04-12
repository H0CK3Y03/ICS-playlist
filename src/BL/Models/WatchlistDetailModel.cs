using System;
using System.Collections.Generic;

namespace BL.Models;

public record WatchlistDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public List<string> MediaFileTitles { get; set; } = new();

    public static WatchlistDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Description = string.Empty,
        MediaFileTitles = new()
    };
}
