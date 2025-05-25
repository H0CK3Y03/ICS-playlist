using System;
using System.Collections.Generic;

namespace Vued.BL.Models;

public record GenreDetailModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public List<string> MediaFileTitles { get; set; } = new();

    public static GenreDetailModel Empty => new()
    {
        Name = string.Empty,
        MediaFileTitles = new()
    };
}
