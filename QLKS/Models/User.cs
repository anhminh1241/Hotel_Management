using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace HotelManagement.Models
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
