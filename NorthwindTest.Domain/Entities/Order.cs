using System;
using System.Collections.Generic;

namespace NorthwindTest.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; } // OrderId (Primary key)
        public DateTime OrderDate { get; set; } // OrderDate
        public string Username { get; set; } // Username
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string Address { get; set; } // Address
        public string City { get; set; } // City
        public string State { get; set; } // State
        public string PostalCode { get; set; } // PostalCode
        public string Country { get; set; } // Country
        public string Phone { get; set; } // Phone
        public string Email { get; set; } // Email
        public decimal Total { get; set; } // Total

        // Reverse navigation
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.Order_OrderDetails;

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
