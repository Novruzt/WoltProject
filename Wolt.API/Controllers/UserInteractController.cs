using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Enums;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [CustomAuth]
    public class UserInteractController : ControllerBase
    {
        private readonly IUserInteractService _UserInteractService;
        private readonly IThingsService _thingsService;

        public UserInteractController(IUserInteractService userInteractService, IThingsService thingsService)
        {

            _thingsService = thingsService;
            _UserInteractService = userInteractService;


        }

        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] AddUserCommentDTO dto)
        {

            string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.AddCommentAsync(token, dto);

            return Ok("You added comment succesfully!");
        }

        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview([FromBody] AddUserReviewDTO dto)
        {
            string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.AddUserReviewAsync(token, dto);

            return Ok("You added review succesfully!");

        }

        [HttpGet("allComments")]
        public async Task<IActionResult> GetAllComments()
        {
            string token = JwtService.GetToken(Request.Headers);

            List<GetAllUserCommentsDTO> list = await _UserInteractService.GetAllCommentsAsync(token);

            if (list.Count == 0)
                return BadRequest("No Comment found");

            return Ok(list);
        }

        [HttpGet("allReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
             string token = JwtService.GetToken(Request.Headers);

            List<GetAllUserReviewsDTO> list = await _UserInteractService.GetAllReviewsAsync(token);

           if (list.Count == 0)
                return BadRequest("No Review found");

            return Ok(list);
        }

        [HttpGet("comment/{commId}")]
        public async Task<IActionResult> GetComment(int commId)
        {

             string token = JwtService.GetToken(Request.Headers);

            GetUserCommentDTO result = await _UserInteractService.GetCommentAsync(token, commId);

            if (result == null)
                return BadRequest("No Comment Found!");

            return Ok(result);
        }

        [HttpGet("review/{revId}")]
        public async Task<IActionResult> GetReview(int revId)
        {

             string token = JwtService.GetToken(Request.Headers);

            GetUserReviewDTO result = await _UserInteractService.GetUserReviewAsync(token, revId);

            if (result == null)
                return BadRequest("No review found!");

            return Ok(result);
        }

        [HttpPut("updateComment")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO dto)
        {

             string token = JwtService.GetToken(Request.Headers);

             await _UserInteractService.UpdateCommentAsync(token, dto);

            return Ok("You updated comment succesfully!");
        }

        [HttpPut("updateReview")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDTO dto)
        {
             string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.UpdateUserReviewAsync(token, dto);

            return Ok("You updated comment succesfully!");
        }

        [HttpDelete("DeleteComment/{commId}")]
        public async Task<IActionResult> DeleteComment(int commId)
        {
             string token = JwtService.GetToken(Request.Headers);

           await _UserInteractService.DeleteCommentAsync(token, commId);

            return Ok("You deleted comment succesfully!");
        }
        [HttpDelete("DeleteReview/{revId}")]
        public async Task<IActionResult> DeleteReview(int revId)
        {
             string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.DeleteUserReviewAsync(token, revId);

            return Ok("You deleted review succesfully!");
        }

        [HttpPost("AddFavoriteFood/{favId}")]
        public async Task<IActionResult> AddFavoriteFood(int favId)
        {
             string token = JwtService.GetToken(Request.Headers);

           await _UserInteractService.AddFavoriteFoodAsync(token, favId);

            return Ok("You added food to favorite succesfully!");
        }

        [HttpPost("AddFavoriteRestaurant/{favId}")]
        public async Task<IActionResult> AddFavoriteRestaurant(int favId)
        {
             string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.AddFavoriteRestaurantAsync(token, favId);

            return Ok("You added restaurant to favorite succesfully!");
        }

        [HttpDelete("DeleteFavoriteFood/{favId}")]
        public async Task<IActionResult> DeleteFavoriteFood(int favId)
        {

             string token = JwtService.GetToken(Request.Headers);

             _UserInteractService.RemoveFavoriteFoodAsync(token, favId);

            return Ok("You deleted food from your favorites succesfully!");
        }

        [HttpDelete("DeleteFavoriteRestaurant/{favId}")]
        public async Task<IActionResult> DeleteFavoriteRestaurant(int favId)
        {
            string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.RemoveFavoriteRestaurantAsync(token, favId);

            return Ok("You deleted restaurant from your favorites succesfully!");
        }

        [HttpDelete("ReturnOrder")]
        public async Task<IActionResult> ReturnOrder(ReturnOrderDTO dto)
        {
             string token = JwtService.GetToken(Request.Headers);

               await _UserInteractService.ReturnOrderAsync(token, dto);

            return Ok("You returned order succesfully!");
        }

        [HttpPost("createBasket")]
        public async Task<IActionResult> CreateBasket([FromBody] AddUserBasketDTO dto)
        {

             string token = JwtService.GetToken(Request.Headers);

             await _UserInteractService.AddUserBasketAsync(token, dto);
            
             return Ok($"You created basket succesfully. Total amount of basket is {dto.TotalAmount}");
        }

        [HttpPut("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket([FromBody] AddUserBasketDTO dto)
        {

             string token = JwtService.GetToken(Request.Headers);

            await _UserInteractService.UpdateUserBasketAsync(token, dto);

            return Ok($"You updated basket succesfully! You total amount is {dto.TotalAmount}");
        }

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
             string token = JwtService.GetToken(Request.Headers);

            GetUserBasketDTO dto = await _UserInteractService.GetUserBasketAsync(token);

            if (dto == null)
                return BadRequest("No Basket Found!");

            if (dto.Products.Count <= 0)
                return BadRequest("There is no any food to see. Please, add some food to your basket.");

            return Ok(dto);
             
        }

        [HttpDelete("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket()
        {
             string token = JwtService.GetToken(Request.Headers);

           await _UserInteractService.DeleteUserBasketAsync(token);

            return Ok("You deleted basket succesfully!");
        }

        [HttpPost("OrderBasket")]
        public async Task<IActionResult> OrderBasket(OrderBasketDTO dto)
        {
             string token = JwtService.GetToken(Request.Headers);

           await _UserInteractService.OrderBasketAsync(token, dto);

            return Ok($"You ordered basket succesfully! Total price is {dto.OrderTotalPrice}");

        }
    }
}
