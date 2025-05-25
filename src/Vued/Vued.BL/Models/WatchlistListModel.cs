using System;

namespace Vued.BL.Models;

public record WatchlistListModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int MediaCount { get; set; }

    public static WatchlistListModel Empty => new();
}
