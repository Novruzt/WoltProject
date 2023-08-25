using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserAuthController(IUserAuthService auth, IThingsService things, IWebHostEnvironment webHostEnvironment)
        {
            _UserAuthService = auth;
            _thingsService = things;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetUserProfile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [CustomAuth]
        public async Task<IActionResult> GetUser()
        {

            string token = JwtService.GetToken(Request.Headers);

            GetUserProfileDTO dto = await _UserAuthService.GetUserAsync(token);

            return Ok(dto);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterUserRequestDTO requestDTO)
        {
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RegisterUserResponseDTO result = await _UserAuthService.RegisterUserAsync(requestDTO);

            return Ok(result);

        }

        [HttpPut("ChangeProfilePicture")]
        [CustomAuth]
        public async Task<IActionResult> ChangeProfilePicture([FromForm] ChangeProfilePictureDTO dto)
        {
            string token = JwtService.GetToken(Request.Headers);

            await _UserAuthService.ChangeProfilePictureAsync(token, dto);

            return Ok("You applied changes.");

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
        [CustomAuth]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO requestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string token = JwtService.GetToken(Request.Headers);

            await _UserAuthService.ResetPasswordAsync(token, requestDTO);

            return Ok("You changed password succesfully!");
        }
      
    }
}
