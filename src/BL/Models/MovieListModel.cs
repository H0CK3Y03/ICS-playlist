using System;
using Domain.Entities;

namespace BL.Models;

public record MovieListModel : ModelBase
{
    public required string Name { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required MediaStatus Status { get; set; }
    public bool Favourite { get; set; }

    public int Length { get; set; }

    public static MovieListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Director = string.Empty,
        ReleaseDate = default,
        Status = default,
        Favourite = default,
        Length = default
    };
}
