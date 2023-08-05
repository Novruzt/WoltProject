using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Services.Abstract;
using WOLT.DAL.Repository.Abstract;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _UserAuthService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            GetUserProfileDTO dto = await _UserAuthService.GetAsync(id);

            return Ok(dto);
        }
    }
}
