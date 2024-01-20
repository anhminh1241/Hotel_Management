using HotelManagement.Models;
using System.Text.Json.Serialization;

namespace HotelManagement.DTO.Auths
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        [JsonIgnore]
        public Role Role { get; set; } = Role.User;
    }
}
