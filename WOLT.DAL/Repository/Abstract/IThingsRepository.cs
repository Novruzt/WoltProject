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
        Task<bool> CheckUserCommentForRestaurantAsync(int userId, int restId);
        Task<bool> CheckUserForEmailAsync(string email);
        Task<bool> CheckLoginUserAsync(string email, string password);
        Task<bool> CheckUserByIdAsync(int Id);
        Task<bool> CheckUserOldPassword(int id, string password);
        Task<bool> CheckUserCurrentPassword(int id, string password);
        Task<bool> CheckUserCommentAsync(int userId, int commId);
        Task<bool> CheckUserOrderAsync(int userId, int orderId);
        Task<bool> CheckUserReviewAsync(int userId, int revId);
        Task<bool> CheckUserReviewForProductAsync(int userId, int productId);
        Task<bool> CheckUserBasketAsync(int userId);
        Task<bool> CheckProductAsync(int id);
    }
}
