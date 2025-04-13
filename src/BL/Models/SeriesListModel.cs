using System;
using DAL.Entities;

namespace BL.Models;

public record SeriesListModel //: ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required MediaStatus Status { get; set; }
    public bool Favourite { get; set; }

    public int NumberOfEpisodes { get; set; }

    public static SeriesListModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Director = string.Empty,
        ReleaseDate = default,
        Status = default,
        Favourite = default,
        NumberOfEpisodes = default
    };
}
