using System.Collections.Generic;

namespace NorthwindTest.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; } // AlbumId (Primary key)
        public int GenreId { get; set; } // GenreId
        public int ArtistId { get; set; } // ArtistId
        public string Title { get; set; } // Title
        public decimal Price { get; set; } // Price
        public string AlbumArtUrl { get; set; } // AlbumArtUrl

        // Reverse navigation
        public virtual ICollection<Cart> Carts { get; set; } // Cart.Cart_Album;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.OrderDetail_Album;

        // Foreign keys
        public virtual Genre Genre { get; set; } //  GenreId - Genre_Albums
        public virtual Artist Artist { get; set; } //  ArtistId - Album_Artist

        public Album()
        {
            Carts = new List<Cart>();
            OrderDetails = new List<OrderDetail>();
        }
    }
}