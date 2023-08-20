using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Enums;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUser()
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            int Id = JwtService.GetIdFromToken(token);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);
            if (!Checker)
                return BadRequest("Invalid token");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDTO requestDTO)
        {
            if (await _thingsService.CheckUserForEmailAsync(requestDTO.Email))
                return BadRequest("This user already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RegisterUserResponseDTO result =  await _UserAuthService.RegisterUserAsync(requestDTO);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO requestDTO)
        {

            if (!await _thingsService.CheckLoginUserAsync(requestDTO.Email, requestDTO.Password))
                return BadRequest("Invalid email or password");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LoginUserResponseDTO result = await _UserAuthService.LoginUserAsync(requestDTO);

            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO requestDTO)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            requestDTO.UserId=JwtService.GetIdFromToken(token);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);
             if (!Checker)
                return BadRequest("Invalid token");

             BaseResultDTO result = await _UserAuthService.ResetPasswordAsync(requestDTO.UserId, requestDTO);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
      
    }
}
