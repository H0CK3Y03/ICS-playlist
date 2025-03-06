namespace Domain.Entities
{
    public class MediaFile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Director { get; set; } = string.Empty;
        public int ReleaseDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;

        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
