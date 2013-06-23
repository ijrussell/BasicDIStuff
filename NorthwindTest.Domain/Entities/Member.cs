namespace NorthwindTest.Domain.Entities
{
    public class Member
    {
        public int MemberId { get; set; } // MemberId (Primary key)
        public string Username { get; set; } // Username
        public string Email { get; set; } // Email
        public string Password { get; set; } // Password
    }
}