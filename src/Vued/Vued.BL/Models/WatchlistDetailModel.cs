using System;
using System.Collections.Generic;

namespace Vued.BL.Models;

public record WatchlistDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public List<string> MediaFileTitles { get; set; } = new();

    public static WatchlistDetailModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Description = string.Empty,
        MediaFileTitles = new()
    };
}
