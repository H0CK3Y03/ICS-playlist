using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MovieListModel //: ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required MediaStatus Status { get; set; }
    public bool Favourite { get; set; }

    public int Length { get; set; }

    public static MovieListModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Director = string.Empty,
        ReleaseDate = default,
        Status = default,
        Favourite = default,
        Length = default
    };
}
