using System;
using System.Collections.Generic;

namespace Vued.BL.Models;

public record WatchlistDetailModel : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<string> MediaFileTitles { get; set; } = new();

    public static WatchlistDetailModel Empty => new()
    {
        Name = string.Empty,
        Description = string.Empty,
        MediaFileTitles = new()
    };
}
