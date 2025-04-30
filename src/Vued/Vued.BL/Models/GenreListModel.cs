using System;

namespace Vued.BL.Models;

public record GenreListModel : ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public static GenreListModel Empty => new()
    {
        Id = 0,
        Name = string.Empty
    };
}
