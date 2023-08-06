using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IThingsRepository
    {
        Task<bool> GetUserCommentAsync(int userId, int restId);
        Task<bool> GetUserAsync(string email);
        Task<bool> LoginUserAsync(string email, string password);
        Task<bool> GetUserByIdAsync(int Id);
        Task<bool> GetUserOldPassword(int id, string password);
        Task<bool> GetUserCurrentPassword(int id, string password);
    }
}
