﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.BLL.Enums;
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

            if (!Checker)
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

            if (!Checker)
                return BadRequest("Invalid token");

            UserFavoriteFoodDTO dto = await _profileService.GetFavoriteFoodAsync(token, favId);

            if (dto == null)
                return BadRequest("No food found!");

            return Ok(dto);

        }

        [HttpGet("AllFavoriteRestaurants")]
        public async Task<IActionResult> GetAllFavoriteRestaurants()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            List<GetAllFavoriteRestaurantsDTO> list = await _profileService.GetAllFavoriteRestaurantsAsync(token);

            if (list.Count == 0)
                return BadRequest("No favorite restaurants found");

            return Ok(list);
        }

        [HttpGet("FavoriteRestaurant/{favId}")]
        public async Task<IActionResult> GetFavoriteRestaurant(int favId)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            UserFavoriteRestaurantDTO dto = await _profileService.GetFavoriteRestaurantsAsync(token, favId);

            if (dto == null)
                return BadRequest("No restaurant found!");

            return Ok(dto);

        }

        [HttpGet("AllUserAdress")]
        public async Task<IActionResult> GetAllUserAddress()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            List<GetAllUserAdressDTO> list = await _profileService.GetAllUserAddressesAsync(token);

            if (list.Count == 0)
                return BadRequest("No adress found");

            return Ok(list);
        }

        [HttpGet("UserHistory")]
        public async Task<IActionResult> GetAllUserHistory()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            List<GetAllUserHistoryDTO> list = await _profileService.GetAllHistoryAsync(token);

            if (list.Count == 0)
                return BadRequest("No history found");

            return Ok(list);
        }

        [HttpGet("UserPayments")]
        public async Task<IActionResult> GetAllUSerPayments()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            List<GetAllUserCardDTO> list = await _profileService.GetAllUserPaymentsAsync(token);

            if (list.Count == 0)
                return BadRequest("No card found! Please, add bank card.");

            return Ok(list);

        }

        [HttpPost("AddUserCard")]
        public async Task<IActionResult> AddUserCard(AddUserPaymentDTO dto)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            BaseResultDTO result = await _profileService.AddUserPayment(token, dto);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);


            return Ok(result.Message);
        }

        [HttpDelete("DeleteCard")]
        public async Task<IActionResult> DeleteUserCard(DeleteUserCardDTO dto)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            BaseResultDTO result = await _profileService.DeleteUserPaymentAsync(token, dto);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);

            return Ok(result.Message);

        }

        [HttpGet("ActiveOrders")]
        public async Task<IActionResult> GetAllActiveOrders()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            List<GetAllUserHistoryDTO> list = await _profileService.GetAllActiveOrdersAsync(token);

            if (list.Count == 0)
                return BadRequest("No history found");


            return Ok(list);
        }

        [HttpGet("GetOrder/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (!Checker)
                return BadRequest("Invalid token");

            GetOrderDTO dto = await _profileService.GetOrderAsync(token, orderId);

            if (dto == null)
                return BadRequest("No order found.");


            return Ok(dto);

        }
    }
}
