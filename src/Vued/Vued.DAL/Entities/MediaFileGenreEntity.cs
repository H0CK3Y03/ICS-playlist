using System;

namespace Vued.DAL.Entities;

public class MediaFileGenreEntity : IEntity
{
    public required Guid Id { get; set; }

    public Guid MediaFileId { get; set; }
    public MediaFileEntity MediaFile { get; set; } = null!;

    public Guid GenreId { get; set; }
    public GenreEntity Genre { get; set; } = null!;
}
