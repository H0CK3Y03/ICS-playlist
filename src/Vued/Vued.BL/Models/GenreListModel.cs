using System;

namespace Vued.BL.Models;

public record GenreListModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public static GenreListModel Empty => new();
}
