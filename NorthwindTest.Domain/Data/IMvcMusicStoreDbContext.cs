using System;
using System.Data.Entity;
using NorthwindTest.Domain.Entities;

namespace NorthwindTest.Domain.Data
{
    public interface IMvcMusicStoreDbContext : IDisposable
    {
        IDbSet<Album> Albums { get; set; } // Album
        IDbSet<Artist> Artists { get; set; } // Artist
        IDbSet<Cart> Carts { get; set; } // Cart
        IDbSet<Genre> Genres { get; set; } // Genre
        IDbSet<Member> Members { get; set; } // Member
        IDbSet<OrderDetail> OrderDetails { get; set; } // OrderDetail
        IDbSet<Order> Orders { get; set; } // Order

        int SaveChanges();
    }
}