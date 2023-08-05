using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.Others;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.DATA;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> AddComment(AddUserCommentDTO dto) 
        {

           if(await _thingsService.GetUserCommentAsync(dto.UserId, dto.RestaurantId)!=null)
            {
                return BadRequest("You already have commented for this restaurant");
            }

            await _UserInteractService.AddCommentAsync(dto);
          

            return Ok(dto);
        }

        [HttpGet("comments/{id}")]
        public async Task<IActionResult> GetAllComments(int id)
        {
            List<GetAllUserCommentsDTO> list = await _UserInteractService.GetAllCommentsAsync(id);

            if (list.Count == 0)
                return BadRequest("No Comment found");

            return Ok(list);
        }

        [HttpGet("comment/{id}/{commId}")]
        public async Task<IActionResult> GetComment(int id, int commId)
        {
            GetUserCommentDTO result = await _UserInteractService.GetCommentAsync(id, commId);

            return Ok(result);
        }


    }
}
