using System.Collections.Generic;

namespace Vued.DAL.Entities;

public class Genre : IEntity
{
    public required int Id { get; set; }
    public string Name { get; set; }

    public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
}
