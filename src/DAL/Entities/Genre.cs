using System.Collections.Generic;

namespace Domain.Entities
{
    public class Genre{
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-many relationship
        public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
    }
}
