using System.Collections.Generic;

namespace DAL.Entities
{
    public class Genre{
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
    }
}
