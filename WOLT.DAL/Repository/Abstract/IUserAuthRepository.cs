using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface  IUserAuthRepository
    {
        Task<User> GetAsync(int id); 
        Task<User> GetByEmailAsync(string email);
        Task RegisterUserAsync(User user); 
        Task DeleteUserAsync(int id); 
        Task ResetPasswordAsync(int id, string newPasswordHash, string newPasswordSalt);
        Task AddOldPasswordAsync(UserOldPassword oldPassword);
        Task ChangeProfilePictureAsync(int id, string? path);
        Task<List<UserOldPassword>> GetAllUserOldPasswordsAsync(int userId);

    }
}
