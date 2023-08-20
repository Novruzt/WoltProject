using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IUserAuthService
    {
        Task<GetUserProfileDTO> GetByEmailAsync(string email);
        Task<GetUserProfileDTO> GetUserAsync(string token); 
        Task<RegisterUserResponseDTO> RegisterUserAsync(RegisterUserRequestDTO dto);
        Task<BaseResultDTO> ResetPasswordAsync(int id, ResetPasswordRequestDTO dto);
        Task<LoginUserResponseDTO> LoginUserAsync(LoginUserRequestDTO dto);
        
    }
}
