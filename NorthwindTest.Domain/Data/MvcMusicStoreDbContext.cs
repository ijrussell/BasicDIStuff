using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using NorthwindTest.Domain.Entities;

//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace NorthwindTest.Domain.Data
{
    // ************************************************************************
    // Unit of work

    // ************************************************************************
    // Database context
    public class MvcMusicStoreDbContext : DbContext, IMvcMusicStoreDbContext
    {
        public IDbSet<Album> Albums { get; set; } // Album
        public IDbSet<Artist> Artists { get; set; } // Artist
        public IDbSet<Cart> Carts { get; set; } // Cart
        public IDbSet<Genre> Genres { get; set; } // Genre
        public IDbSet<Member> Members { get; set; } // Member
        public IDbSet<OrderDetail> OrderDetails { get; set; } // OrderDetail
        public IDbSet<Order> Orders { get; set; } // Order

        static MvcMusicStoreDbContext()
        {
            Database.SetInitializer<MvcMusicStoreDbContext>(null);
        }

        public MvcMusicStoreDbContext()
            : base("Name=MvcMusicStore")
        {
        }

        public MvcMusicStoreDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlbumsConfiguration());
            modelBuilder.Configurations.Add(new ArtistsConfiguration());
            modelBuilder.Configurations.Add(new CartsConfiguration());
            modelBuilder.Configurations.Add(new GenresConfiguration());
            modelBuilder.Configurations.Add(new MembersConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());
            modelBuilder.Configurations.Add(new OrdersConfiguration());
        }
    }



    // ************************************************************************
    // POCO Configuration

    // Album
    internal class AlbumsConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumsConfiguration()
        {
            ToTable("dbo.Albums");
            HasKey(x => x.AlbumId);

            Property(x => x.AlbumId).HasColumnName("AlbumId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GenreId).HasColumnName("GenreId").IsRequired();
            Property(x => x.ArtistId).HasColumnName("ArtistId").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(160);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasPrecision(18,2);
            Property(x => x.AlbumArtUrl).HasColumnName("AlbumArtUrl").IsOptional().HasMaxLength(1024);

            // Foreign keys
            HasRequired(a => a.Genre).WithMany(b => b.Albums).HasForeignKey(c => c.GenreId); // Genre_Albums
            HasRequired(a => a.Artist).WithMany(b => b.Albums).HasForeignKey(c => c.ArtistId); // Album_Artist
        }
    }

    // Artist
    internal class ArtistsConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistsConfiguration()
        {
            ToTable("dbo.Artists");
            HasKey(x => x.ArtistId);

            Property(x => x.ArtistId).HasColumnName("ArtistId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional();
        }
    }

    // Cart
    internal class CartsConfiguration : EntityTypeConfiguration<Cart>
    {
        public CartsConfiguration()
        {
            ToTable("dbo.Carts");
            HasKey(x => x.RecordId);

            Property(x => x.RecordId).HasColumnName("RecordId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CartId).HasColumnName("CartId").IsOptional();
            Property(x => x.AlbumId).HasColumnName("AlbumId").IsRequired();
            Property(x => x.Count).HasColumnName("Count").IsRequired();
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();

            // Foreign keys
            HasRequired(a => a.Album).WithMany(b => b.Carts).HasForeignKey(c => c.AlbumId); // Cart_Album
        }
    }

    // Genre
    internal class GenresConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenresConfiguration()
        {
            ToTable("dbo.Genres");
            HasKey(x => x.GenreId);

            Property(x => x.GenreId).HasColumnName("GenreId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Description).HasColumnName("Description").IsOptional();
        }
    }

    // Member
    internal class MembersConfiguration : EntityTypeConfiguration<Member>
    {
        public MembersConfiguration()
        {
            ToTable("dbo.Members");
            HasKey(x => x.MemberId);

            Property(x => x.MemberId).HasColumnName("MemberId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Username).HasColumnName("Username").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();
            Property(x => x.Password).HasColumnName("Password").IsOptional();
        }
    }

    // OrderDetail
    internal class OrderDetailsConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailsConfiguration()
        {
            ToTable("dbo.OrderDetails");
            HasKey(x => x.OrderDetailId);

            Property(x => x.OrderDetailId).HasColumnName("OrderDetailId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.AlbumId).HasColumnName("AlbumId").IsRequired();
            Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsRequired().HasPrecision(18,2);

            // Foreign keys
            HasRequired(a => a.Order).WithMany(b => b.OrderDetails).HasForeignKey(c => c.OrderId); // Order_OrderDetails
            HasRequired(a => a.Album).WithMany(b => b.OrderDetails).HasForeignKey(c => c.AlbumId); // OrderDetail_Album
        }
    }

    // Order
    internal class OrdersConfiguration : EntityTypeConfiguration<Order>
    {
        public OrdersConfiguration()
        {
            ToTable("dbo.Orders");
            HasKey(x => x.OrderId);

            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderDate).HasColumnName("OrderDate").IsRequired();
            Property(x => x.Username).HasColumnName("Username").IsOptional();
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(160);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(160);
            Property(x => x.Address).HasColumnName("Address").IsRequired().HasMaxLength(70);
            Property(x => x.City).HasColumnName("City").IsRequired().HasMaxLength(40);
            Property(x => x.State).HasColumnName("State").IsRequired().HasMaxLength(40);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsRequired().HasMaxLength(10);
            Property(x => x.Country).HasColumnName("Country").IsRequired().HasMaxLength(40);
            Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(24);
            Property(x => x.Email).HasColumnName("Email").IsRequired();
            Property(x => x.Total).HasColumnName("Total").IsRequired().HasPrecision(18,2);
        }
    }

}

