using System;
using System.Collections.Generic;

namespace BL.Models;

public record GenreDetailModel : ModelBase
{
    public required string Name { get; set; }

    //public List<string> MediaFileTitles { get; set; } = new(); ???

    public static GenreDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        MediaFileTitles = new()
    };
}
