using System;
using System.Collections.Generic;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record SeriesDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required MediaStatus Status { get; set; }
    public required string Description { get; set; }
    public required int Duration { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required string Rating { get; set; }
    public string? URL { get; set; }
    public bool Favourite { get; set; }

    public int NumberOfEpisodes { get; set; }

    public List<string> GenreNames { get; set; } = new();

    public static SeriesDetailModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Status = default,
        Description = string.Empty,
        Duration = default,
        Director = string.Empty,
        ReleaseDate = default,
        Rating = string.Empty,
        URL = null,
        Favourite = default,
        NumberOfEpisodes = default,
        GenreNames = new()
    };
}
