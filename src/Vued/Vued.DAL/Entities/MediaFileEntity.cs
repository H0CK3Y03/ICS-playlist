using System.Collections.Generic;

namespace Vued.DAL.Entities;

public enum MediaStatus
{
    PlanToWatch,
    Watching,
    Completed,
    Dropped
}

public enum MediaType
{
    Movie,
    Series
}

public class MediaFile : IEntity
{
    public required int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MediaStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Director { get; set; } = string.Empty;
    public int ReleaseDate { get; set; }
    public string Rating { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public bool Favourite { get; set; } = false;
    public string Review { get; set; } = string.Empty;
    public required MediaType MediaType { get; set; }

    public ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
