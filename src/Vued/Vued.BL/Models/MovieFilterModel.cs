using Vued.DAL.Entities;

namespace Vued.BL.Models
{
    public record MovieFilterModel
    {
        public string? TitleContains { get; set; }
        public string? DirectorContains { get; set; }
        public string? Genre {  get; set; }
        public int? ReleaseYear { get; set; }
        public bool? Favourite { get; set; }
        public int? LengthMax { get; set; }
        public MediaStatus? Status { get; set; }

        public string? SortBy { get; set; } = "Alphabetical";
        public string? SortOrder { get; set; } = "asc";
    }
}
