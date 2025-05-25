using System;
using System.Collections.Generic;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MovieDetailModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MediaStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Director { get; set; } = string.Empty;
    public int ReleaseDate { get; set; }
    public string Rating { get; set; } = string.Empty;
    public string? URL { get; set; }
    public bool Favourite { get; set; }
    public int Length { get; set; }

    public List<string> GenreNames { get; set; } = new();

    public static MovieDetailModel Empty => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Status = default,
        Description = string.Empty,
        Duration = 0,
        Director = string.Empty,
        ReleaseDate = 0,
        Rating = string.Empty,
        URL = null,
        Favourite = false,
        Length = 0,
        GenreNames = new()
    };
}
