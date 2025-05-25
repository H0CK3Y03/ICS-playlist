using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record SeriesListModel : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int ReleaseDate { get; set; }
    public MediaStatus Status { get; set; }
    public bool Favourite { get; set; }
    public int NumberOfEpisodes { get; set; }

    public static SeriesListModel Empty => new();
}
