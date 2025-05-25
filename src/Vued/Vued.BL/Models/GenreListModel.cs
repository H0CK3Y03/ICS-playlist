using System;

namespace Vued.BL.Models;

public record GenreListModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static GenreListModel Empty => new();
}
