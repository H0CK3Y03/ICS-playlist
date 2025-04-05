using System;
using Domain.Entities;

namespace BL.Models;

public record SeriesListModel : ModelBase
{
    public required string Name { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required MediaStatus Status { get; set; }
    public bool Favourite { get; set; }

    public int NumberOfEpisodes { get; set; }

    public static SeriesListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Director = string.Empty,
        ReleaseDate = default,
        Status = default,
        Favourite = default,
        NumberOfEpisodes = default
    };
}
