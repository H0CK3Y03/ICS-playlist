using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MovieListModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int ReleaseDate { get; set; }
    public MediaStatus Status { get; set; }
    public bool Favourite { get; set; }
    public int Length { get; set; }

    public static MovieListModel Empty => new();
}
