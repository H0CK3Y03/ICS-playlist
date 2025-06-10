using System;
using System.Collections.Generic;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MediaFileModel : ModelBase
{
    public required string Name { get; set; }
    public required MediaStatus Status { get; set; }
    public required string Description { get; set; }
    public required int Duration { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required string Rating { get; set; }
    public string? URL { get; set; }
    public string? ImageURL { get; set; }
    public bool Favourite { get; set; }
    public string Review { get; set; }
    public MediaType MediaType { get; set; }

    public List<string> GenreNames { get; set; } = new();

    public static MediaFileModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Status = MediaStatus.PlanToWatch,
        Description = string.Empty,
        Duration = 0,
        Director = string.Empty,
        ReleaseDate = 0,
        Rating = string.Empty,
        ImageURL = null,
        URL = null,
        Favourite = false,
        Review = string.Empty,
        GenreNames = new()
    };
}
