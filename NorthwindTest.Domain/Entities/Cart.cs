using System;

namespace NorthwindTest.Domain.Entities
{
    public class Cart
    {
        public int RecordId { get; set; } // RecordId (Primary key)
        public string CartId { get; set; } // CartId
        public int AlbumId { get; set; } // AlbumId
        public int Count { get; set; } // Count
        public DateTime DateCreated { get; set; } // DateCreated

        // Foreign keys
        public virtual Album Album { get; set; } //  AlbumId - Cart_Album
    }
}