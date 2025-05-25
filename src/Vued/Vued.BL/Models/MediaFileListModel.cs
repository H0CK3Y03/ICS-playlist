using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MediaFileListModel : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public MediaStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Director { get; set; } = string.Empty;
    public int ReleaseDate { get; set; }
    public string Rating { get; set; } = string.Empty;
    public string? URL { get; set; }
    public bool Favourite { get; set; }

    public static MediaFileListModel Empty => new();
}
