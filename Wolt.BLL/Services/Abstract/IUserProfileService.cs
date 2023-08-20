using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IUserProfileService
    {
        Task<List<GetAllUserFavoriteFoodsDTO>> GetAllFavoriteFoodAsync(string token);
        Task<UserFavoriteFoodDTO> GetFavoriteFoodAsync(string token, int favId);
        Task<List<GetAllFavoriteRestaurantsDTO>> GetAllFavoriteRestaurantsAsync(string token);
        Task<UserFavoriteRestaurantDTO> GetFavoriteRestaurantsAsync(string token, int favId);
        Task<List<UserAddress>> GetAllUserAddressesAsync(string token);
        Task<UserAddress> GetUserAddressesAsync(string token, int addressId);
        Task<List<UserHistory>> GetAllHistoryAsync(string token);
        Task<List<UserPayment>> GetAllUserPaymentsAsync(string token);
        Task AddUserPayment(UserPayment payment);
        Task DeleteUserPaymentAsync(string token, int PaymentId);
        Task<List<Order>> GetAllOrdersAsync(string token);
        Task<Order> GetOrderAsync(string token, int OrderId);
    }
}
