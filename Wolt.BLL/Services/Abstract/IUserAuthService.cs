using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IUserAuthService
    {
        Task<GetUserProfileDTO> GetAsync(int id);
        Task RegisterUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task ResetPasswordAsync(int id, string newPassword);
    }
}
