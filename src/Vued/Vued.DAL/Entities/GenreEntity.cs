using System;
using System.Collections.Generic;

namespace Vued.DAL.Entities;

public class GenreEntity : IEntity
{
    public required Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<MediaFileGenreEntity> MediaFileGenres { get; set; } = new List<MediaFileGenreEntity>();
}
