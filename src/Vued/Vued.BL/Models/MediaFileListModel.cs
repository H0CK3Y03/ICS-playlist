using System;
using Vued.DAL.Entities;

namespace Vued.BL.Models;

public record MediaListModel : ModelBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public MediaStatus Status { get; set; }
    public required string Description { get; set; }
    public required int Duration { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required string Rating { get; set; }
    public string? URL { get; set; }
    public bool Favourite { get; set; }

    public static MediaListModel Empty => new()
    {
        Id = 0,
        Name = string.Empty,
        Status = MediaStatus.PlanToWatch,
        Description = string.Empty,
        Duration = 0,
        Director = string.Empty,
        ReleaseDate = 0,
        Rating = string.Empty,
        URL = null,
        Favourite = false

        //MediaFiles = entity.MediaFiles
        //.Select(MediaMapper.MapToListModel)
        //.Where(m => m is not null)
        //.ToList()!
    };
}
