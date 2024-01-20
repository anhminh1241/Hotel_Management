using HotelManagement.DTO.Auths;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO req)
        {
            return Ok(await _userService.Login(req));
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO req)
        {
            await _userService.Register(req);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> OnlyAdmin()
        {
            return Ok("Admin");
        }

        //phai dang nhap
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MustLogin()
        {
            return Ok("ok");
        }

    }
}
