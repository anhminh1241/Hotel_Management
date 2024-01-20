
using HotelManagement.DTO.Auths;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string email, string hashedPassword);
        Task<UserClientDTO> Login(LoginDTO req);
        Task Register(RegisterDTO user);

    }
}
