using System;
using System.Collections.Generic;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record SeriesDetailModel : ModelBase
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
    public int NumberOfEpisodes { get; set; }

    public List<string> GenreNames { get; set; } = new();

    public static SeriesDetailModel Empty => new()
    {
        Name = string.Empty,
        Description = string.Empty,
        Director = string.Empty,
        Rating = string.Empty,
        URL = null,
        GenreNames = new()
    };
}
