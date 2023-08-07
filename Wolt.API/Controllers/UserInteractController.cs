using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Enums;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.DATA;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserInteractController : ControllerBase
    {
        private readonly IUserInteractService _UserInteractService;
        private readonly IThingsService _thingsService;

        public UserInteractController(IUserInteractService userInteractService, IThingsService thingsService)
        {

            _thingsService = thingsService;
            _UserInteractService = userInteractService;


        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] AddUserCommentDTO dto)
        {
            

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            dto.UserId = JwtService.GetIdFromToken(token);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            

            if (await _thingsService.CheckUserCommentForRestaurantAsync(dto.UserId, dto.RestaurantId))
            {
                return BadRequest("You already have commented for this restaurant");
            }

            await _UserInteractService.AddCommentAsync(dto);


            return Ok(dto);
        }

        [HttpGet("allComments")]
        public async Task<IActionResult> GetAllComments()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            

            List<GetAllUserCommentsDTO> list = await _UserInteractService.GetAllCommentsAsync(token);

            if (list.Count == 0)
                return BadRequest("No Comment found");

            return Ok(list);
        }

        [HttpGet("allReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            List<GetAllUserReviewsDTO> list = await _UserInteractService.GetAllReviewsAsync(token);

           if (list.Count == 0)
                return BadRequest("No Review found");

            return Ok(list);
        }

        [HttpGet("comment/{commId}")]
        public async Task<IActionResult> GetComment(int commId)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            GetUserCommentDTO result = await _UserInteractService.GetCommentAsync(token, commId);

            return Ok(result);
        }

        [HttpGet("review/{revId}")]
        public async Task<IActionResult> GetReview(int revId)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            GetUserReviewDTO result = await _UserInteractService.GetUserReviewAsync(token, revId);

            return Ok(result);
        }

        [HttpPut("updateComment")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO dto)
        {

            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            BaseResultDTO result = await _UserInteractService.UpdateCommentAsync(token, dto);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("updateReview")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDTO dto)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            BaseResultDTO result = await _UserInteractService.UpdateUserReviewAsync(token, dto);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("deletecomment{commId}")]
        public async Task<IActionResult> DeleteComment(int commId)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            BaseResultDTO result= await _UserInteractService.DeleteCommentAsync(token, commId);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);


            return Ok(result.Message);
        }

        [HttpDelete("ReturnOrder")]
        public async Task<IActionResult> ReturnOrder(ReturnOrderDTO dto)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token not provided");

            bool Checker = await _thingsService.CheckUserByToken(token);

            if (Checker = false)
                return BadRequest("Invalid token");

            BaseResultDTO result = await _UserInteractService.ReturnOrderAsync(token, dto);

            if (result.Status == RequestStatus.Failed)
                return BadRequest(result.Message);


            return Ok(result.Message);
        }

       


    }
}
