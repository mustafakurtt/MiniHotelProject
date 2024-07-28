using Business.Abstract;
using Entities.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLoginResponse = await _authService.LoginAsync(userForLoginDto);
            if (!userToLoginResponse.Success)
                return BadRequest(userToLoginResponse.Message);
            
            var result = await _authService.CreateAccessToken(userToLoginResponse.Data);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Data);
            

            
        }

    }
}
