using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.Repositories.Interfaces;
using HotelManagement.DTO.Auths;
using AutoMapper;

namespace HotelManagement.Services.Impls
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IAuthService authService, IMapper mapper)
        {
            _userRepo = userRepo;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            // Tìm người dùng bằng email
            var user = await _userRepo.FindAll(x => x.Email == email && x.HashedPassword == password).FirstOrDefaultAsync();

            // Nếu không tìm thấy người dùng hoặc mật khẩu không đúng, trả về null
            if (user == null )
                return null;

            // Nếu tất cả đều hợp lệ, trả về thông tin người dùng
            return user;
        }
        

        public async Task<UserClientDTO> Login(LoginDTO user)
        {
            var _user = await Authenticate(user.UserName, user.Password);
            var token = await _authService.CreateTokenAsync(_user);
            return new UserClientDTO()
            {
                DisplayName = _user.FirstName + " " + _user.LastName,
                Token = token
            };
        }

        public async Task Register(RegisterDTO user)
        {
           await _userRepo.Add(_mapper.Map<User>(user));
        }
    }
}
