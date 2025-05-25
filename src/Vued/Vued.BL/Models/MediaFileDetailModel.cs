using System;
using System.Collections.Generic;
using Vued.DAL.Entities;

namespace Vued.BL.Models;
public enum MediaType
{
    Movie,
    Series
}
public record MediaFileModel : ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required MediaStatus Status { get; set; }
    public required string Description { get; set; }
    public required int Duration { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required string Rating { get; set; }
    public string? URL { get; set; }
    public bool Favourite { get; set; }
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
        URL = null,
        Favourite = false,
        GenreNames = new()
    };
}
