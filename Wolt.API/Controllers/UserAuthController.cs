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

            if (dto == null)
            {
                return BadRequest("No user exist.");
            }

            return Ok(dto);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterUserRequestDTO requestDTO)
        {
            if (await _thingsService.CheckUserForEmailAsync(requestDTO.Email))
                return BadRequest("This user already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (requestDTO.ProfilePic != null)
                {

                    if (!FileService.IsImage(requestDTO.ProfilePic))
                        return BadRequest("Upload valid image.");

                    string currPath = _webHostEnvironment.ContentRootPath;
                    string fullPath = FileService.SaveImage(requestDTO.ProfilePic, _webHostEnvironment);

                    requestDTO.ProfilePicture = fullPath;
                }

                RegisterUserResponseDTO result = await _UserAuthService.RegisterUserAsync(requestDTO);

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
   
        }

        [HttpPut("ChangeProfilePicture")]
        [CustomAuth]
        public async Task<IActionResult> ChangeProfilePicture([FromForm] ChangeProfilePictureDTO dto)
        {
            string token = JwtService.GetToken(Request.Headers);

            dto.UserId = JwtService.GetIdFromToken(token);

            string fullPath=null;

            GetUserProfileDTO ProfileDTO = await _UserAuthService.GetUserAsync(token);

            if (ProfileDTO == null)
            {
                return BadRequest("No user exist.");
            }



            string oldPath = ProfileDTO.ProfilePicture;

            try
            {
                if (dto.ProfilePic != null)
                {

                    if (!FileService.IsImage(dto.ProfilePic))
                        return BadRequest("Upload valid image.");

                    string currPath = _webHostEnvironment.ContentRootPath;
                    fullPath= FileService.SaveImage(dto.ProfilePic, _webHostEnvironment);

                   
                }

                if (oldPath != null)
                    FileService.DeleteImage(oldPath, _webHostEnvironment);

                BaseResultDTO result = await _UserAuthService.ChangeProfilePictureAsync(token, fullPath);

                if (result.Status == RequestStatus.Failed)
                    return BadRequest(result.Message);

                return Ok(result.Message);

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

          
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

            string token = JwtService.GetToken(Request.Headers);

            requestDTO.UserId=JwtService.GetIdFromToken(token);

             BaseResultDTO result = await _UserAuthService.ResetPasswordAsync(requestDTO.UserId, requestDTO);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
      
    }
}
