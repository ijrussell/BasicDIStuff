using System.Collections.Generic;

namespace NorthwindTest.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; } // ArtistId (Primary key)
        public string Name { get; set; } // Name

        // Reverse navigation
        public virtual ICollection<Album> Albums { get; set; } // Album.Album_Artist;

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}