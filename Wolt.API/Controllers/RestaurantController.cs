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
            GetRestaurantDTO dto = await _restaurantService.GetAsync(id);

            if (dto == null)
                return BadRequest("No Restaurant Found");

            return Ok(dto);
        }
    }
}
