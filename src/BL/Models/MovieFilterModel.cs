using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
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

        public string? SortBy { get; set; } = "title";
        public string? SortOrder { get; set; } = "asc";
    }
}
