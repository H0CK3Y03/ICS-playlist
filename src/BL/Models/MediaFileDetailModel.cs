using System;
using System.Collections.Generic;
using Domain.Entities;

namespace BL.Models;

public record MediaFileDetailModel : ModelBase
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

    public List<string> GenreNames { get; set; } = new();

    public static MediaFileDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Status = MediaStatus.PlanToWatch,
        Description = string.Empty,
        Duration = entity.Duration,
        Director = string.Empty,
        ReleaseDate = entity.ReleaseDate,
        Rating = string.Empty,
        URL = null,
        Favourite = false,
        GenreNames = new()
    };
}
