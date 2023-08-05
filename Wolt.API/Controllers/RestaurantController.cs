using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.Entities.Entities.RestaurantEntities;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        

        public RestaurantController(IRestaurantService service)
        {
            _restaurantService = service;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllRestaurantsDTO> list = await _restaurantService.GetAllAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetRestaurantDTO list = await _restaurantService.GetAsync(id);

            if (list == null)
                return BadRequest("No Restaurant Found");

            return Ok(list);
        }

        [HttpGet("allcategories/{id}")]
        public async Task<IActionResult> GetAllCategories(int id) 
        {
            
            List<GetAllCategoriesDTO> list = await _restaurantService.GetAllCategoriesAsync(id);

            if (list.Count==0)
                return BadRequest("No Category Found");

            return Ok(list);
        }

        [HttpGet("allcomments/{id}")]
        public async Task<IActionResult> GetAllUserComments(int id)
        {
            List<GetAllUserCommentsForRestaurantDTO> list = await _restaurantService.GetAllCommentsAsync(id);

            if (list.Count == 0)
                return BadRequest("No Comment Found");

            return Ok(list);
        }

        [HttpGet("allproducts/{id}")]
        public async Task<IActionResult> GetAllProducts(int id)
        {
            List<GetAllProductsDTO> list = await _restaurantService.GetAllProductsAsync(id);

            if (list.Count == 0)
                return BadRequest("This Category is empty");

            return Ok(list);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductDTO dto = await _restaurantService.GetProductAsync(id);

            if (dto == null)
                return BadRequest("No Product found");

            return Ok(dto);
        }

        [HttpGet("userReviewsForProducts/{id}")]
        public async Task<IActionResult> GetAllReviews(int id)
        {
            List<GetAllReviewsForProductDTO> list = await _restaurantService.GetUserReviewsAsync(id);

            if (list.Count == 0)
                return BadRequest("No Review found");

            return Ok(list);


        }
    }
}
