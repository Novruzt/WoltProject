using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using WOLT.DAL.Repository.Abstract;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _UserAuthService;
        private readonly IThingsService _thingsService;

        public UserAuthController(IUserAuthService auth, IThingsService things)
        {
            _UserAuthService = auth;
            _thingsService = things;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            GetUserProfileDTO dto = await _UserAuthService.GetAsync(id);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDTO requestDTO)
        {
            if (await _thingsService.GetUserAsync(requestDTO.Email))
                return BadRequest("This user already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RegisterUserResponseDTO result =  await _UserAuthService.RegisterUserAsync(requestDTO);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO requestDTO)
        {

            if (!await _thingsService.LoginUserAsync(requestDTO.Email, requestDTO.Password))
                return BadRequest("Invalid email or password");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LoginUserResponseDTO result = await _UserAuthService.LoginUserAsync(requestDTO);

            return Ok(result);
        }

        [HttpPost("ResetPasswords")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ResetPasswords([FromBody] ResetPasswordRequestDTO requestDTO)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            int UserId = JwtService.GetIdFromToken(token);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.GetUserByToken(token);
             if (Checker = false)
                return BadRequest("Invalid token");

             string result = await _UserAuthService.ResetPasswordAsync(UserId, requestDTO);

            return Ok(result);
        }
      
    }
}
