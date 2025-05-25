using System;
using System.Collections.Generic;

namespace Vued.BL.Models;

public record GenreModel : ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    //public List<string> MediaFileTitles { get; set; } = new(); ???

    public static GenreModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        //MediaFileTitles = new()
    };
}
