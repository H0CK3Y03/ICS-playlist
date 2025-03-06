namespace Domain.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MediaCount => MediaFiles?.Count ?? 0;
        public int TotalDuration => MediaFiles?.Sum(t => t.Duration) ?? 0;

        public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
    }
}
