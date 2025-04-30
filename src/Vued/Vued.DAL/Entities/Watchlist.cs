using System.Collections.Generic;

namespace Vued.DAL.Entities;

public class Watchlist
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int MediaCount => MediaFiles?.Count ?? 0;

    public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
}
