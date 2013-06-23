namespace NorthwindTest.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } // OrderDetailId (Primary key)
        public int OrderId { get; set; } // OrderId
        public int AlbumId { get; set; } // AlbumId
        public int Quantity { get; set; } // Quantity
        public decimal UnitPrice { get; set; } // UnitPrice

        // Foreign keys
        public virtual Order Order { get; set; } //  OrderId - Order_OrderDetails
        public virtual Album Album { get; set; } //  AlbumId - OrderDetail_Album
    }
}