using System;

namespace BL.Models;

public record GenreListModel : ModelBase
{
    public required string Name { get; set; }

    public static GenreListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty
    };
}
