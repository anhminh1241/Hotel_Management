using HotelManagement.DTO.Auths;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(User user);


    }
}
