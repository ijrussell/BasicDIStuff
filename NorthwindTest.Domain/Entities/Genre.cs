using System.Collections.Generic;

namespace NorthwindTest.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; } // GenreId (Primary key)
        public string Name { get; set; } // Name
        public string Description { get; set; } // Description

        // Reverse navigation
        public virtual ICollection<Album> Albums { get; set; } // Album.Genre_Albums;

        public Genre()
        {
            Albums = new List<Album>();
        }
    }
}