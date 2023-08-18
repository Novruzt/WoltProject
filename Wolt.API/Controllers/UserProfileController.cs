using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Services.Concrete;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _profileService;
        private readonly IThingsService _thingsService;


        public UserProfileController(IUserProfileService userProfileService, IThingsService thingsService)
        {
            _profileService = userProfileService;
            _thingsService = thingsService;
        }

        [HttpGet("AllFavoriteFoods")]
        public async Task<IActionResult> GetAllFavoriteFoods()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            List<GetAllUserFavoriteFoodsDTO> list = await _profileService.GetAllFavoriteFoodAsync(token);

            if (list.Count == 0)
                return BadRequest("No favorite foods found");

            return Ok(list);
        }

        [HttpGet("FavoriteFood/{favId}")]
        public async Task<IActionResult> GetFavoriteFood(int favId)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            UserFavoriteFoodDTO dto = await _profileService.GetFavoriteFoodAsync(token, favId);

            if (dto == null)
                return BadRequest("No food found!");

            return Ok(dto);

        }

    }
}
