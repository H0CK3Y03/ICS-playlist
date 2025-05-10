using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MediaListModel : ModelBase
{
    public required string Name { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required MediaStatus Status { get; set; }
    public bool Favourite { get; set; }

    public static MediaListModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Director = string.Empty,
        ReleaseDate = 0,
        Status = MediaStatus.PlanToWatch,
        Favourite = false

        //MediaFiles = entity.MediaFiles
        //.Select(MediaMapper.MapToListModel)
        //.Where(m => m is not null)
        //.ToList()!
    };
}
